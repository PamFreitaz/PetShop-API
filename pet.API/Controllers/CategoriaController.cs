using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pet.Application.Interfaces;
using pet.Domain.Entity;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("categoria")]
    [Authorize(Roles = "Admin")]
    public class CategoriaController : ControllerBase
    {
        public readonly ICategoriaService categoriaService;
        public CategoriaController(ICategoriaService service)
        {
            categoriaService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCategoria([FromBody] Categoria categoria)
        {
            await categoriaService.AdicionarCategoria(categoria);
            return Ok("Categoria criada com sucesso");
        }
        [HttpGet]
        public async Task<IActionResult> ListarCategoria()
        {
            var categorias = await categoriaService.ListarCategoria();
            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCategoriaPorId(long id)
        {
            var categoria = await categoriaService.BuscarCategoriaPorId(id);
            return Ok(categoria);
        }
    }
}

