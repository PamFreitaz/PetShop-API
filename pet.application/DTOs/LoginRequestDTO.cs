using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginRequestDTO(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}
