using pet.Application.DTOs;
using pet.Application.Handler;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using pet.Domain.Enum;
using pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository repository;
        public readonly IAuthService authService;
        public UsuarioService(IUsuarioRepository usuarioRepository, IAuthService auth)
        {
            repository = usuarioRepository;
            authService = auth;
        }
        public Task CadastrarUsuario(UsuarioCreateDTO usuario)
        {
            UsuarioUtil.ValidarUsuario(usuario);
            var DataCriacao = DateTime.Now;
            var UsuarioEntity = new Usuario
            {
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                Senha = usuario.Senha,
                TipoUsuario = usuario.TipoUsuario,
                DataCadastro = DataCriacao
            };
            UsuarioEntity.Senha = authService.HashSenha(UsuarioEntity, UsuarioEntity.Senha);

            return repository.Cadastrar(UsuarioEntity);
        }
        private UsuarioResponseDTO ConverterParaDTO(Usuario usuario)
        {
            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                DataCadastro = usuario.DataCadastro,
                TipoUsuario = usuario.TipoUsuario,
            };
        }


        public async Task<List<UsuarioResponseDTO>> ListarUsuarios()
        {
            var usuarios = await repository.Listar();
            return usuarios.Select(ConverterParaDTO).ToList();
        }

        public async Task<UsuarioResponseDTO> BuscarPorId(long id)
        {
            var usuario = await repository.BuscarPorId(id);
            return ConverterParaDTO(usuario);
        }
        public async Task<List<PetResponseDTO>> BuscarPets(long id)
        {
            var pets = await repository.BuscarPets(id);
            return pets.Select(pet => new PetResponseDTO
            {
                Id = pet.Id,
                Nome = pet.Nome,
                DataNascimento = pet.DataNascimento,
                TutorId = pet.TutorId,
                Especie = pet.Especie,
                Ativo = pet.Ativo,
                Porte = pet is Cachorro cachorro ? cachorro.Porte : null,
                Raca = pet is Cachorro c ? c.Raca : (pet is Gato gato ? gato.Raca : null),
                Cor = pet is Cachorro c2 ? c2.Cor : (pet is Gato g2 ? g2.Cor : null),
            }).ToList();
        }

        public async Task AtualizarUsuario(long id, UsuarioUpdateDTO usuarioDTO)
        {
            var usuario = await repository.BuscarPorId(id);
            if (usuarioDTO.Nome != null)
            {
                usuario.Nome = usuarioDTO.Nome;
            }
            if (usuarioDTO.Email != null)
            {
                usuario.Email = usuarioDTO.Email;
            }
            if (usuarioDTO.Telefone != null)
            {
                usuario.Telefone = usuarioDTO.Telefone;
            }
            if (usuarioDTO.Senha  != null)
            {
                usuario.Senha = usuarioDTO.Senha;
            }
            if (usuarioDTO.DataNascimento.HasValue)
            {
                usuario.DataNascimento = usuarioDTO.DataNascimento.Value ;
            }
            if (usuarioDTO.TipoUsuario.HasValue)
            {
                usuario.TipoUsuario = usuarioDTO.TipoUsuario.Value;
            }
               
            await repository.Atualizar(usuario);
        }

        public async Task<List<UsuarioResponseDTO>> ListarPorTipo(TipoUsuario tipoUsuario)
        {
            var usuarios = await repository.ListarPorUsuario(tipoUsuario);
            return usuarios.Select(ConverterParaDTO).ToList();
        }

    }
}
