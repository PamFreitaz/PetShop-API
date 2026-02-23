using pet.Domain.Entity;
using pet.Domain.Interfaces;
using pet.Infrastructure.ConexaoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
                var SqlQuery = "SELECT id, nome, data_nascimento::timestamp AS DataNascimento, tutor_id AS TutorId, especie, porte, raca, cor, ativo FROM pet WHERE tutor_id = @Id";
                return (await dbConnection.QueryAsync<Pet>(SqlQuery, new { Id = id })).ToList();
            }
        }

     


        /*
        public Task AlterarDados(long id, Tutor tutor)
        {

        }*/
    }
}
