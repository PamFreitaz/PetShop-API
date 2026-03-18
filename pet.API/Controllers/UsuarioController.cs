using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using pet.Domain.Enum;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService service;
        public UsuarioController(IUsuarioService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioCreateDTO usuario)
        {
            await service.CadastrarUsuario(usuario);
            return Ok("Cadastro realizado com sucesso!");
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await service.ListarUsuarios();
            return Ok(usuarios);
        }
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            var usuarios = await service.BuscarPorId(id);
            return Ok(usuarios);
        }
        //[Authorize]
        [HttpGet("listarpets/{id}")]
        public async Task<IActionResult> BuscarPetPorUsuario(long id)
        {
            var pets = await service.BuscarPets(id);
            return Ok(pets);
        }
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(long id, UsuarioUpdateDTO usuarioDTO)
        {
            await service.AtualizarUsuario(id, usuarioDTO);
            return Ok(usuarioDTO);
        }

        //[Authorize(Roles = "Admin, Funcionario")]
        [HttpGet("clientes")]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await service.ListarPorTipo(TipoUsuario.Cliente);
            return Ok(clientes);
        }

    }
}
