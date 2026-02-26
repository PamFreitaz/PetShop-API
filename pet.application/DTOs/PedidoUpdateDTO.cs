using pet.Domain.Entity;
using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class PedidoUpdateDTO
    {
        public double? ValorTotal { get; set; }
        public List<ItemPedido>? ItensPedidos { get; set; } = new();
        public StatusPedido? StatusPedido { get; set; }

        public PedidoUpdateDTO()
        {
            
        }
        public PedidoUpdateDTO(double? valorTotal, List<ItemPedido>? itensPedidos, StatusPedido? statusPedido)
        {
            ValorTotal = valorTotal;
            ItensPedidos = itensPedidos;
            StatusPedido = statusPedido;
        }
    }
}
