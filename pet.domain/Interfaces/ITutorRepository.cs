using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface ITutorRepository
    {
        Task Cadastrar(Tutor tutor);
        Task<List<Tutor>> Listar();
        Task <Tutor> BuscarPorId(long id);
        
        Task<List<Pet>> BuscarPets(long id);
        /*
        Task AlterarDados(long id, Tutor tutor);*/
    }
}
