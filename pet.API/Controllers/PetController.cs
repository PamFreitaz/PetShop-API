using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("pet")]
    public class PetController : ControllerBase
    {
        public readonly IPetService service;

        public PetController(IPetService PetService)
        {
            service = PetService;
        }
        [HttpPost]

        public async Task<IActionResult> AdicionarPet([FromBody] PetCreateDTO Pet)
        {
            await service.AdicionarPet(Pet);
            return Ok("Pet adicionado com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(long id)
        {
            var pet = await service.BuscarPorId(id);
            return Ok(pet);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(long id)
        {
            await service.DesativarPet(id);
            return Ok("Deletado com sucesso!");
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var pets = await service.ListarPet();
            return Ok(pets);
        }

        [HttpGet("ativos")]
        public async Task<IActionResult> ListarAtivos()
        {
            var pets = await service.ListarPetsAtivos();
            return Ok(pets);
        }

    }
}
