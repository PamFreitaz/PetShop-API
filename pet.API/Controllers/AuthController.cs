using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Interfaces;

namespace pet.API.Controllers
{

    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService service;

        public AuthController(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            service = authService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            var usuario = await _usuarioRepository.BuscarPorEmail(dto.Email);

            if (usuario == null || !service.VerificarSenha(usuario, dto.Senha))
                return Unauthorized("Email ou senha inválidos");

            var token = service.GerarToken(usuario);
            return Ok(token);
        }
    }
}
