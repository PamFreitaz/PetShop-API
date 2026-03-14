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
    public class TutorRepository : ITutorRepository
    {
        public readonly DbConnection connection;
        public TutorRepository(DbConnection Db)
        {
            connection = Db;
        }

        public async Task Cadastrar(Tutor tutor)
        {
            using (var dbConnection = connection.CreateConnection())
            {                                      //nomes que estão na tabela banco de dados     X      nomes que estão na entidade
                var SqlQuery = "INSERT INTO tutor (nome, cpf, email, telefone, data_nascimento) values (@Nome, @Cpf, @Email, @Telefone, @DataNascimento)";
                await dbConnection.ExecuteAsync(SqlQuery, tutor);
            }
        }
        public async Task<List<Tutor>> Listar()
        {
            using (var dbConnenction = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, cpf, email, telefone, data_nascimento::timestamp AS DataNascimento FROM tutor";
                return (await dbConnenction.QueryAsync<Tutor>(SqlQuery)).ToList();
            }
        }

        public async Task <Tutor> BuscarPorId(long id)
        {
            using (var dbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, cpf, email, telefone, data_nascimento::timestamp AS DataNascimento FROM tutor WHERE id = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<Tutor>(SqlQuery,new {Id = id});
            }
        }

        public async Task<List<Pet>> BuscarPets(long id)
        {
            using (var dbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, data_nascimento::timestamp AS DataNascimento, tutor_id AS TutorId, especie, porte AS Porte, raca AS Raca, cor AS Cor, ativo FROM pet WHERE tutor_id = @Id";
                var resultado = await dbConnection.QueryAsync<dynamic>(SqlQuery, new { Id = id });

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

        /*
        public Task AlterarDados(long id, Tutor tutor)
        {

        }*/
    }
}
