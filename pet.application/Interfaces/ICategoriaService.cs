using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task AdicionarCategoria(Categoria categoria);
        Task<List<Categoria>> ListarCategoria();
        Task<Categoria> BuscarCategoriaPorId(long id);
        
    }
}
