using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Usuario
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        //public Endereco endereco { get; set; }

        public List<Pet>? Pets { get; set; }
        public DateTime DataCadastro { get; set; }

        public Usuario()
        {
            
        }

        public Usuario(long id, string nome, string cpf, string email, string telefone, DateTime dataNascimento, string senha, TipoUsuario tipoUsuario, List<Pet>? pets, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Pets = pets;
            DataCadastro = dataCadastro;
        }
    }
}
