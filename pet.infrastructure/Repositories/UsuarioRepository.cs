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
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly DbConnection connection;
        public UsuarioRepository(DbConnection Db)
        {
            connection = Db;
        }

        public async Task Cadastrar(Usuario usuario)
        {
            using (var dbConnection = connection.CreateConnection())
            {                                      //nomes que estão na tabela banco de dados     X      nomes que estão na entidade
                var SqlQuery = "INSERT INTO usuario (nome, cpf, email, telefone, data_nascimento, senha, tipo_usuario) values (@Nome, @Cpf, @Email, @Telefone, @DataNascimento, @Senha, @TipoUsuario)";
                await dbConnection.ExecuteAsync(SqlQuery, usuario);
            }
        }
        public async Task<List<Usuario>> Listar()
        {
            using (var dbConnenction = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, cpf, email, telefone, data_nascimento::timestamp AS DataNascimento, senha, tipo_usuario AS TipoUsuario, data_cadastro::timestamp AS DataCadastro FROM usuario";
                return (await dbConnenction.QueryAsync<Usuario>(SqlQuery)).ToList();
            }
        }

        public async Task <Usuario> BuscarPorId(long id)
        {
            using (var dbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, cpf, email, telefone, data_nascimento::timestamp AS DataNascimento, senha,tipo_usuario AS TipoUsuario, data_cadastro::timestamp AS DataCadastro FROM usuario WHERE id = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<Usuario>(SqlQuery,new {Id = id});
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
        public async Task<Usuario> BuscarPorEmail(string email)
        {
            using (var dbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, cpf, email, telefone, data_nascimento::timestamp AS DataNascimento, senha, tipo_usuario AS TipoUsuario, data_cadastro::timestamp AS DataCadastro FROM usuario WHERE email = @Email";
                return await dbConnection.QueryFirstOrDefaultAsync<Usuario>(SqlQuery, new { Email = email });
            }
        }
        
        public async Task Atualizar(Usuario usuario)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "UPDATE usuario SET nome = @Nome, cpf = @Cpf, email = @Email, telefone = @Telefone, data_nascimento = @DataNascimento, senha = @Senha, tipo_usuario = @TipoUsuario WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery,usuario);
            }
        }

        public async Task<List<Usuario>> ListarPorUsuario(TipoUsuario tipoUsuario)
        {
            using (var DbConnection = connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, cpf, email, telefone, data_nascimento::timestamp AS DataNascimento, senha, tipo_usuario AS TipoUsuario, data_cadastro::timestamp AS DataCadastro FROM usuario WHERE tipo_usuario = @TipoUsuario";
                return (await DbConnection.QueryAsync<Usuario>(SqlQuery, new { TipoUsuario = tipoUsuario })).ToList();
            }
        }
    }
}
