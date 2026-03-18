using pet.Domain.Entity;
using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class UsuarioUpdateDTO
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Senha { get; set; }
        public TipoUsuario? TipoUsuario { get; set; }
        public List<Pet>? Pets { get; set; }
        public UsuarioUpdateDTO()
        {
            
        }

        public UsuarioUpdateDTO(string? nome, string? email, string? telefone, DateTime? dataNascimento, string? senha, TipoUsuario? tipoUsuario, List<Pet>? pets)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Pets = pets;
        }
    }
}
