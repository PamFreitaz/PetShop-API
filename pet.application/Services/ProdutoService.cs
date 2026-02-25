using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Services
{
    public class ProdutoService : IProdutoService
    {

        public readonly IProdutoRepository ProdutoRepository;

        public ProdutoService(IProdutoRepository Repository)
        {
            ProdutoRepository = Repository;
        }

        public Task CadastrarProduto(Produto produto)
        {
            return ProdutoRepository.Cadastrar(produto);
        }

        public Task<List<Produto>> ListarProduto()
        {
            return ProdutoRepository.Listar();
        }

        public Task<Produto> BuscarProduto(long id)
        {
            return ProdutoRepository.Buscar(id);
        }

        public async Task AtualizarProduto(long id, ProdutoUpdateDTO produto)
        {
            var produtoExistente = await BuscarProduto(id);

            if (produtoExistente == null)
            {
                throw new Exception("Produto não encontrado");
            }
            if (produto.Nome != null)
            {
                produtoExistente.Nome = produto.Nome;
            }   
            if (produto.Descricao != null)
            {
                produtoExistente.Descricao = produto.Descricao;
            }
            if (produto.Valor.HasValue)
            {
                produtoExistente.Valor = produto.Valor.Value;
            }
            if (produto.Ativo.HasValue)
            {
                produtoExistente.Ativo = produto.Ativo.Value;
            }

            await ProdutoRepository.Atualizar(produtoExistente);
        }

        public Task DeletarProduto(long id)
        {
            return ProdutoRepository.Deletar(id);
        }
    }
}
