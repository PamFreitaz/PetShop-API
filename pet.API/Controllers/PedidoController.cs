using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;

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

    }
}
