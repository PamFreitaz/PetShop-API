using Dapper;
using pet.Domain.Entity;
using pet.Domain.Interfaces;
using pet.Infrastructure.ConexaoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Infrastructure.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        public readonly DbConnection Connection;

        public ItemPedidoRepository(DbConnection Db)
        {
            Connection = Db;
        }

        public async Task<long> Adicionar(ItemPedido itemPedido)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO item_pedido (pedido_id, produto_id, quantidade, valor_unitario, subtotal) VALUES (@PedidoId, @ProdutoId, @Quantidade, @ValorUnitario, @Subtotal) returning id";
                return await DbConnection.ExecuteScalarAsync<long>(SqlQuery, itemPedido);
            }
        }
    }
}
