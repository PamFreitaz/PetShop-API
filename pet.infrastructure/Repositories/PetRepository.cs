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
    public class PetRepository : IPetRepository
    {
        public readonly DbConnection connection;
        public PetRepository(DbConnection Db)
        {
            connection = Db;
        }
        public async Task AdicionarCachorro(Cachorro cachorro)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO pet (nome, data_Nascimento, tutor_id, especie, porte, raca, cor, ativo) VALUES (@Nome, @DataNascimento, @TutorId, @Especie, @Porte, @Raca, @Cor, @Ativo)";
                await DbConnection.ExecuteAsync(SqlQuery, cachorro);
            }
        }
        public async Task AdicionarGato(Gato gato)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO pet (nome, data_Nascimento, tutor_id, especie, raca, cor, ativo) VALUES (@Nome, @DataNascimento, @TutorId, @Especie, @Raca, @Cor, @Ativo)";
                await DbConnection.ExecuteAsync(SqlQuery, gato);
            }
        }

        public async Task<Pet> BuscarPorId(long id)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, data_nascimento::timestamp AS DataNascimento, tutor_id AS TutorId, especie, porte, raca, cor, ativo FROM pet WHERE id = @id";
                return await DbConnection.QueryFirstOrDefaultAsync<Pet>(SqlQuery, new{Id = id });
            }
        }

        public async Task Desativar(long id)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "UPDATE pet SET ativo = false WHERE Id = @id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id });
            }
        }

        public async Task<List<Pet>> Listar()
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, data_nascimento::timestamp AS DataNascimento, tutor_id AS TutorId, especie, porte, raca, cor, ativo FROM pet";
                return (await DbConnection.QueryAsync<Pet>(SqlQuery)).ToList();
            }
        }
    }
}
