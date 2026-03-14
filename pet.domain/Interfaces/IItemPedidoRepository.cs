using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface IItemPedidoRepository
    {
        //Long pq vai retornar o ID do itemPedido
        Task<long> Adicionar(ItemPedido itemPedido);
        Task RemoverItensPedido(long id);
    }
}
