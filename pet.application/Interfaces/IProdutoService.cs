using pet.Application.DTOs;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface IProdutoService
    {
        Task CadastrarProduto(Produto produto);
        Task<List<Produto>> ListarProduto();
        Task<Produto> BuscarProduto(long id);
        Task AtualizarProduto(long id, ProdutoUpdateDTO produto);
        Task DeletarProduto(long id);

    }
}
