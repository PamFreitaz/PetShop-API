using pet.Application.DTOs;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface IPedidoService
    {
        Task CriarPedido(PedidoCreateDTO pedido);
        Task <Pedido> BuscarPedidoPorId(long id);
        Task <List<Pedido>> ListarPedidos();
        Task<List<Pedido>> ListarPedidosPorTutor(long id);
        Task AtualizarPedido(long id, PedidoUpdateDTO pedidoDTO);
        Task CancelarPedido(long id);
        Task MudarStatusPedido(long id, PedidoUpdateDTO pedidoDTO);
    }
}
