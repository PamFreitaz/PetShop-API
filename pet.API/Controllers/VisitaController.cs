using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Application.Services;
using pet.Domain.Entity;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("Visita")]
    [Authorize (Roles = "Admin, Funcionario")]
    public class VisitaController : ControllerBase
    {
        public readonly IVisitaService VisitaService;
        public VisitaController(IVisitaService visita)
        {
            VisitaService = visita;
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarVisita([FromBody] VisitaCreateDTO Visita)
        {
            await VisitaService.AdicionarVisita(Visita);
            return Ok("Visita criada com sucesso!");
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var visitas = await VisitaService.ListarVisita();
            return Ok(visitas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarporId(long id)
        {
            var visitas = await VisitaService.BuscarVisitaPorId(id);
            return Ok(visitas);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(long id, VisitaUpdateDTO Visita)
        {
            await VisitaService.AtualizarVisita(id, Visita);
            return Ok("Visita atualizada com sucesso");
        }
        [HttpDelete("cancelar/{id}")]
        public async Task<IActionResult> Cancelar(long id)
        {
            await VisitaService.CancelarVisita(id);
            return Ok("Visita Cancelada com sucesso");
        }

        [HttpPut("finalizar/{id}")]
        public async Task<IActionResult> Finalizar(long id)
        {
            await VisitaService.FinalizarVisita(id);
            return Ok("Visita Finalizada com Sucesso");
        }
    }
}


