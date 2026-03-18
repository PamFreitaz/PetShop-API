using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiracao { get; set; }

        public LoginResponseDTO(string token, DateTime expiracao)
        {
            Token = token;
            Expiracao = expiracao;
        }
    }
}
