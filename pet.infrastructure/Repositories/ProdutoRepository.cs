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
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly DbConnection Connection;

        public ProdutoRepository(DbConnection Db)
        {
            Connection = Db;
        }

        public async Task Cadastrar(Produto produto)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "INSERT INTO produto (nome, descricao, valor, ativo, categoria_id, quantidade_estoque) VALUES (@Nome, @Descricao, @Valor, @Ativo, @CategoriaId, @QuantidadeEstoque)";
                await DbConnection.ExecuteAsync(SqlQuery, produto);
            }    
        }

        public async Task<List<Produto>> Listar()
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, descricao, valor, ativo, categoria_id AS CategoriaId, quantidade_estoque AS QuantidadeEstoque FROM produto";
                return (await DbConnection.QueryAsync<Produto>(SqlQuery)).ToList();
            }
        }

        public async Task<Produto> Buscar(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, descricao, valor, ativo, categoria_id AS CategoriaId, quantidade_estoque AS QuantidadeEstoque FROM produto WHERE Id = @Id";
                return await DbConnection.QueryFirstOrDefaultAsync<Produto>(SqlQuery, new { Id = id });
            }
        }

        public async Task Atualizar(Produto produto)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE produto SET nome = @Nome, descricao = @Descricao, valor = @Valor, ativo = @Ativo, categoria_id = @CategoriaId WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, produto);
            }
        }

        public async Task DarBaixa(int Estoque, long id, IDbConnection connection, IDbTransaction transaction)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "UPDATE produto SET quantidade_estoque = @QuantidadeEstoque WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id, QuantidadeEstoque = Estoque }, transaction);
            }
        }

        public async Task Deletar(long id)
        {
            using (var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "DELETE * FROM produto WHERE Id = @Id";
                await DbConnection.ExecuteAsync(SqlQuery, new { Id = id });
            }
        }

        public async Task<List<Produto>> ListarPorCategoria(long id)
        {
            using ( var DbConnection = Connection.CreateConnection())
            {
                var SqlQuery = "SELECT id, nome, descricao, valor, ativo, categoria_id AS CategoriaId FROM produto WHERE categoria_id = @CategoriaId";
                return (await DbConnection.QueryAsync<Produto>(SqlQuery,new {CategoriaId = id})).ToList();
            }
        }
    }
}
