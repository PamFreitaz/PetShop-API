using Dapper;
using pet.Domain.Entity;
using pet.Domain.Enum;
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
                var SqlQuery = "SELECT id, nome, data_nascimento::timestamp AS DataNascimento, tutor_id AS TutorId, especie, porte AS Porte, raca AS Raca, cor AS Cor, ativo FROM pet WHERE id = @id";
                var resultado = await DbConnection.QueryFirstOrDefaultAsync<dynamic>(SqlQuery, new { Id = id });

                var especie = (Especie)resultado.especie;
                if (resultado == null)
                    return null;

                if (especie == Especie.Cachorro)
                {
                    return new Cachorro(
                        resultado.id,
                        resultado.nome,
                        resultado.datanascimento,
                        resultado.tutorid,
                        especie,
                        resultado.ativo,
                        (Porte)resultado.porte,
                        resultado.raca,
                        resultado.cor
                        );
                }

                if (especie == Especie.Gato)
                {
                    return new Gato
                    (
                        resultado.Id,
                        resultado.Nome
                    );
                }

                throw new Exception("Tipo de pet inválido");
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
                var SqlQuery = "SELECT id, nome, data_nascimento::timestamp AS DataNascimento, tutor_id AS TutorId, especie, porte AS Porte, raca AS Raca, cor AS Cor, ativo FROM pet";
                var resultado = await DbConnection.QueryAsync<dynamic>(SqlQuery);

                //usando lambda
                return resultado.Select<dynamic, Pet>(r =>
                {
                    var especie = (Especie)r.especie;
                    if (especie == Especie.Cachorro)
                        return new Cachorro(r.id, r.nome, r.datanascimento, r.tutorid, especie, r.ativo, (Porte)r.porte, r.raca, r.cor);
                    if (especie == Especie.Gato)
                        return new Gato(r.id, r.nome, r.datanascimento, r.tutorid, especie, r.ativo, r.raca, r.cor);
                    throw new Exception("Tipo de pet inválido");
                }).ToList();
            }
        }
    }
}
