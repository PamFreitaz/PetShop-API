using pet.Domain.Entity;
using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class UsuarioCreateDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        //não é obrigatório, mas pode ser útil para consultas futuras
        public List<Pet>? Pets { get; set; }
        public UsuarioCreateDTO()
        {

        }

        public UsuarioCreateDTO(string nome, string cpf, string email, string telefone, DateTime dataNascimento, string senha, TipoUsuario tipoUsuario, List<Pet>? pets)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Pets = pets;
        }
    }
}

