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
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly DbConnection Connection;

        public CategoriaRepository(DbConnection Db)
        {
            Connection = Db;
        }

        public async Task Adicionar(Categoria categoria)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO categoria (nome, descricao) VALUES (@Nome, @Descricao)";
                await DbConnection.ExecuteAsync(SqlQuery, categoria);
            }
        }

        public async Task<Categoria> BuscarPorId(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT * FROM categoria WHERE ID = @Id";
                return await DbConnection.QueryFirstOrDefaultAsync<Categoria>(SqlQuery, new {Id = id});
            }
        }

        public async Task<List<Categoria>> Listar()
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT * FROM categoria";
                return (await DbConnection.QueryAsync<Categoria>(SqlQuery)).ToList();
            }
        }
    }
}
