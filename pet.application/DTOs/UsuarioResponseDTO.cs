using pet.Domain.Entity;
using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class UsuarioResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        //public Endereco endereco { get; set; }
        public DateTime DataCadastro { get; set; }

        public UsuarioResponseDTO()
        {
            
        }

        public UsuarioResponseDTO(long id, string nome, string cpf, string email, string telefone, DateTime dataNascimento, TipoUsuario tipoUsuario, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            TipoUsuario = tipoUsuario;
            DataCadastro = dataCadastro;
        }
    }
}
