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
    public class PedidoRepository : IPedidoRepository
    {

        public readonly DbConnection Connection;
        public PedidoRepository(DbConnection Db)
        {
            Connection = Db;
        }

        public async Task<long> Adicionar(Pedido pedido)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO pedido (data_criacao, valor_total, status, tutor_id) VALUES (@DataCriacao, @ValorTotal, @StatusPedido, @TutorId) returning id";
                return await DbConnection.ExecuteScalarAsync<long>(SqlQuery, pedido);
            }
        }

        public async Task AtualizarTotal(long id, double Total)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE pedido SET valor_total = @ValorTotal WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id, ValorTotal = Total });
            }   
        }
    }
}

