using pet.Application.DTOs;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface IAuthService
    {
        public LoginResponseDTO GerarToken(Usuario usuario);
        public string HashSenha (Usuario usuario, string senha);
        public bool VerificarSenha(Usuario usuario, string senha);
    }

}
