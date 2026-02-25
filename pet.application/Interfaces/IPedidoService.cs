using pet.Application.DTOs;
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
    }
}
