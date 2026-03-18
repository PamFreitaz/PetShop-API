using pet.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pet.Application.Handler
{
    public static class UsuarioUtil
    {
        public static void ValidarUsuario(UsuarioCreateDTO usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new Exception("O nome é obrigatório");

            if (usuario.Nome.Length < 3)
                throw new Exception("O nome deve ter pelo menos 3 caracteres");

            if (string.IsNullOrWhiteSpace(usuario.Cpf))
                throw new Exception("O CPF é obrigatório");

            if (!Regex.IsMatch(usuario.Cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
                throw new Exception("CPF inválido. Use o formato 000.000.000-00");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("O e-mail é obrigatório");

            if (!Regex.IsMatch(usuario.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("E-mail inválido");

            if (string.IsNullOrWhiteSpace(usuario.Telefone))
                throw new Exception("O telefone é obrigatório");

            if (!Regex.IsMatch(usuario.Telefone, @"^\d{10,11}$"))
                throw new Exception("Telefone inválido. Use apenas números com DDD");

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new Exception("A senha é obrigatória");

            if (usuario.Senha.Length < 6)
                throw new Exception("A senha deve ter pelo menos 6 caracteres");
        }
    }
}
