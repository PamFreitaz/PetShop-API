using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class ItemPedidoDTO
    {
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public ItemPedidoDTO()
        {
            
        }

        public ItemPedidoDTO(long produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}
