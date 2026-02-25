using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class ItemPedido
    {
        public long Id { get; set; }
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario {  get; set; }

        public double Subtotal { get; set; }

        public ItemPedido()
        {
            
        }

        public ItemPedido(long id, long pedidoId, long produtoId, int quantidade, double valorUnitario, double subtotal)
        {
            Id = id;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Subtotal = subtotal;
        }
    }
}
