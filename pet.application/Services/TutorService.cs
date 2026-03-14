using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Services
{
    public class TutorService : ITutorService
    {
        public readonly ITutorRepository repository;
        public TutorService(ITutorRepository tutorRepository)
        {
            repository = tutorRepository;
        }
        public Task CadastrarTutor(TutorCreateDTO tutor)
        {
            var DataCriacao = DateTime.Now;
            var TutorEntity = new Tutor
            {
                Nome = tutor.Nome,
                Cpf = tutor.Cpf,
                Email = tutor.Email,
                Telefone = tutor.Telefone,
                DataNascimento = tutor.DataNascimento,
                DataCadastro = DataCriacao
            };
            return repository.Cadastrar(TutorEntity);
        }

        public Task<List<Tutor>> ListarTutores()
        {
            return repository.Listar();
        }

        public Task <Tutor> BuscarPorId(long id)
        {
            return repository.BuscarPorId(id);
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

        /*public Task AlterarDadosTutor(long id, Tutor tutor)
        {
            
        }*/



    }
}
