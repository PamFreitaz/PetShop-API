using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class TutorCreateDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        //não é obrigatório, mas pode ser útil para consultas futuras
        public List<Pet>? Pets { get; set; }
        public TutorCreateDTO()
        {

        }

        public TutorCreateDTO(string nome, string cpf, string email, string telefone, DateTime dataNascimento, List<Pet>? pets)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Pets = pets;
        }
    }
}

