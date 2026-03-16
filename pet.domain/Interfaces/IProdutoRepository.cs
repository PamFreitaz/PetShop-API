using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task Cadastrar(Produto produto);
        Task<List<Produto>> Listar();
        Task<Produto> Buscar(long id);
        Task Atualizar(Produto produto);
        Task Deletar(long id);
        Task<List<Produto>>ListarPorCategoria(long id);
        Task DarBaixa(int Estoque, long id, IDbConnection connection, IDbTransaction transaction);
    }
}
