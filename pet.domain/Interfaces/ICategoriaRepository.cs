using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task Adicionar(Categoria categoria);
        Task<List<Categoria>> Listar();
        Task<Categoria> BuscarPorId(long id);
    }
}
