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
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository CategoriaRepository;
        public CategoriaService(ICategoriaRepository Repository)
        {
            CategoriaRepository = Repository;
        }

        public Task AdicionarCategoria(Categoria categoria)
        {
            return CategoriaRepository.Adicionar(categoria);
        }

        public async Task<Categoria> BuscarCategoriaPorId(long id)
        {
            var categoria = await CategoriaRepository.BuscarPorId(id);
            if(categoria == null)
            {
                throw new Exception("Categoria não encontrada!");
            }
            return categoria;
        }

        public Task<List<Categoria>> ListarCategoria()
        {
            return CategoriaRepository.Listar();
        }
    }
}
