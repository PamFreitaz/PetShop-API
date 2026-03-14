using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using System.Reflection.Metadata.Ecma335;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("pedido")]
    public class PedidoController : ControllerBase
    {
        public readonly IPedidoService pedidoService;
        public PedidoController(IPedidoService servicePedido)
        {
            pedidoService = servicePedido;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoCreateDTO pedido)
        {
            await pedidoService.CriarPedido(pedido);
            return Ok("Pedido Criado com Sucesso");
        }
        [HttpGet("buscarpedidoporid/{id}")]
        public async Task<IActionResult> BuscarPedidoPorId(long id)
        {
            var buscarPedido = await pedidoService.BuscarPedidoPorId(id);
            return Ok(buscarPedido);
        }
        [HttpGet]
        public async Task<IActionResult> ListarPedido()
        {
            var listarPedidos = await pedidoService.ListarPedidos();
            return Ok(listarPedidos);
        }
        [HttpGet("listarportutor/{id}")]
        public async Task<IActionResult> ListarPedidosPorTutor(long id)
        {
            var listarPorTutor = await pedidoService.ListarPedidosPorTutor(id);
            return Ok(listarPorTutor);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPedido(long id, PedidoUpdateDTO pedido)
        {
            await pedidoService.AtualizarPedido(id, pedido);
            return Ok("Pedido Atualizado com Sucesso");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarPedido(long id)
        {
            await pedidoService.CancelarPedido(id);
            return Ok("Pedido cancelado com sucesso");
        }
        [HttpPut("atualizarstatus/{id}")]
        public async Task<IActionResult> MudarStatusPedido(long id, PedidoUpdateDTO pedidoDTO)
        {
            await pedidoService.MudarStatusPedido(id, pedidoDTO);
            return Ok("Status atualizado com sucesso");
        }
    }
}
