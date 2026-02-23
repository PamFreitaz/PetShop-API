using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("tutor")]
    public class TutorController : ControllerBase
    {
        public readonly ITutorService service;
        public TutorController(ITutorService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] TutorCreateDTO tutor)
        {
            await service.CadastrarTutor(tutor);
            return Ok("Cadastro realizado com sucesso!");
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var tutores = await service.ListarTutores();
            return Ok(tutores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            var tutores = await service.BuscarPorId(id);
            return Ok(tutores);
        }
        [HttpGet("listarpets/{id}")]
        public async Task<IActionResult> BuscarPetPorTutor(long id)
        {
            var pets = await service.BuscarPets(id);
            return Ok(pets);
        }

    }
}
