using Dapper;
using Npgsql.Replication.PgOutput.Messages;
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
    public class ServicoRepository : IServicoRepository
    {
        public readonly DbConnection connection;
        public ServicoRepository(DbConnection Db)
        {
            connection = Db;
        }

        public async Task Adicionar(Servico servico)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO servico (nome, descricao, preco, ativo) VALUES (@Nome, @Descricao, @Preco, @Ativo) ";
                await DbConnection.ExecuteAsync(SqlQuery, servico);
            }
        }

        public async Task Alterar(long id, Servico servico)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "UPDATE servico SET nome = @Nome, descricao = @Descricao, preco = @Preco, ativo = @Ativo WHERE id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id, servico.Nome, servico.Descricao, servico.Preco, servico.Ativo });
            }
        }

        public async Task<Servico> BuscarPorId(long id)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, preco,ativo FROM servico WHERE Id = @Id";
                return await DbConnection.QueryFirstOrDefaultAsync<Servico>(SqlQuery, new { Id = id});
            }
        }

        public async Task Desativar(long id)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "UPDATE servico set ativo = false WHERE id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new {Id = id});
            }
        }

        public async Task<List<Servico>> Listar()
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, descricao, preco, ativo FROM servico";
                return (await DbConnection.QueryAsync<Servico>(SqlQuery)).ToList();
            }
        }
    }
}
