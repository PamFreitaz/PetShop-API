using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface IPetRepository
    {
        Task AdicionarCachorro(Cachorro cachorro);
        Task AdicionarGato(Gato gato);
        Task<List<Pet>> Listar();
        Task Desativar(long id);
        Task<Pet> BuscarPorId(long id);
        Task <List<Pet>> ListarAtivos();
    }
}
