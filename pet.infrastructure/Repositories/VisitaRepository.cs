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
    public class VisitaRepository : IVisitaRepository
    {
        public readonly DbConnection Connection;
        public VisitaRepository(DbConnection Db)
        {
            Connection = Db;
        }

        public async Task Adicionar(Visita visita)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO visita (data_visita, servicos, pet_id, valor, status) VALUES (@Data, @Servicos, @PetId, @Valor, @statusVisita)";
                await DbConnection.ExecuteAsync(SqlQuery, visita);
            }
        }

        public async Task Atualizar(Visita visita)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE visita SET data_visita = @data, servicos = @servicos, pet_id = @PetId, valor = @valor, status = @statusVisita WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, visita);
            }    
        }

        public async Task<Visita> BuscarPorId(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, data_visita::timestamp AS data, servicos, pet_id, valor, status AS statusVisita FROM visita WHERE Id = @Id ";
                return await DbConnection.QueryFirstOrDefaultAsync<Visita>(SqlQuery, new { Id = id });
            }
        }

        public async Task Cancelar(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE visita SET status = 3 WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id });
            }
        }

        public async Task<List<Visita>> Listar()
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, data_visita::timestamp AS data, servicos, pet_id AS PetId, valor, status AS statusVisita FROM visita";
                return (await DbConnection.QueryAsync<Visita>(SqlQuery)).ToList();
            }
        }
        public async Task Finalizar(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE visita SET status = 2 WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id });
            }
        }
    }
}
