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
    public class ServicoRepository : IServicoRepository
    {
        public readonly DbConnection connection;
        public ServicoRepository(DbConnection Db)
        {
            connection = Db;
        }
        public async Task<Servico> BuscarPorId(long id)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, preco FROM servico WHERE Id = @Id";
                return await DbConnection.QueryFirstOrDefaultAsync<Servico>(SqlQuery, new { Id = id});
            }
        }
    }
}
