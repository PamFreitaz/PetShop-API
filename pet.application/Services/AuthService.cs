using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Services
{
    public class AuthService : IAuthService
    {
        // IConfiguration para pegar as configurações do appsettings.json
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<Usuario> hashSenha = new();

        public AuthService(IConfiguration iConfiguration)
        {
            _configuration = iConfiguration;
        }

        public LoginResponseDTO GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString())
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(
                int.Parse(_configuration["Jwt:ExpireMinutes"]!)
            );

            var jwtToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new LoginResponseDTO(token, expires);
        }

        public string HashSenha(Usuario usuario, string senha)
        {
            return hashSenha.HashPassword(usuario, senha);
        }

        public bool VerificarSenha(Usuario usuario, string senhaDigitada)
        {
            var resultado = hashSenha.VerifyHashedPassword(usuario, usuario.Senha, senhaDigitada);
            return resultado == PasswordVerificationResult.Success;
        }
    }
}
