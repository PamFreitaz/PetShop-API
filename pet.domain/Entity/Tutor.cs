using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Tutor
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        //não é obrigatório, mas pode ser útil para consultas futuras
        public List<Pet>? Pets { get; set; }
        public DateTime DataCadastro { get; set; }

        public Tutor()
        {
            
        }

        public Tutor(long id, string nome, string cpf, string email, string telefone, DateTime dataNascimento, List<Pet>? pets, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Pets = pets;
            DataCadastro = dataCadastro;
        }
    }
}
