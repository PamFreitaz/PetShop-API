using Dapper;
using pet.Domain.Entity;
using pet.Domain.Interfaces;
using pet.Infrastructure.ConexaoDb;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<long> Adicionar(Pedido pedido, IDbConnection connection, IDbTransaction transaction)
        {
                var SqlQuery = "INSERT INTO pedido (data_criacao, valor_total, status, tutor_id) VALUES (@DataCriacao, @ValorTotal, @StatusPedido, @TutorId) returning id";
                return await connection.ExecuteScalarAsync<long>(SqlQuery, pedido, transaction);
        }

        public async Task AtualizarTotal(long id, double Total, IDbConnection connection, IDbTransaction transaction)
        {
                var SqlQuery = "UPDATE pedido SET valor_total = @ValorTotal WHERE Id = @Id";
                await connection.ExecuteAsync(SqlQuery, new { Id = id, ValorTotal = Total }, transaction);
        }

        public async Task<Pedido> BuscarPorId(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id , data_criacao::timestamp AS DataCriacao, valor_total AS ValorTotal, status AS StatusPedido, tutor_id AS TutorId FROM pedido WHERE Id = @Id";
                return await DbConnection.QueryFirstOrDefaultAsync<Pedido>(SqlQuery, new { Id = id });
            }
        }

        public async Task<List<Pedido>> Listar()
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id , data_criacao::timestamp AS DataCriacao, valor_total AS ValorTotal, status AS StatusPedido, tutor_id AS TutorId FROM pedido ";
                return (await DbConnection.QueryAsync<Pedido>(SqlQuery)).ToList();
            }
        }

        public async Task<List<Pedido>> ListarPorTutor(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id , data_criacao::timestamp AS DataCriacao, valor_total AS ValorTotal, status AS StatusPedido, tutor_id AS TutorId FROM pedido WHERE tutor_id = @TutorId";
                return (await DbConnection.QueryAsync<Pedido>(SqlQuery, new {TutorId =  id})).ToList();
            }
        }
        public async Task Atualizar(long id, Pedido pedido)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE pedido SET data_criacao = @DataCriacao, valor_total = @ValorTotal, status = @StatusPedido, tutor_id = @TutorId WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, pedido);
            }
        }
        public async Task Cancelar(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE pedido SET status = 4 WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id });
            }
        }

        public async Task MudarStatus(long id, Pedido pedido)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE pedido SET status = @StatusPedido WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, pedido);
            }
        }
    }
}

