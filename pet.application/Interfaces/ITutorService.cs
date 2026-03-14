using pet.Application.DTOs;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface ITutorService
    {
        Task CadastrarTutor(TutorCreateDTO tutor);
        Task<List<Tutor>> ListarTutores();
        Task <Tutor> BuscarPorId(long id);

        
        Task<List<PetResponseDTO>> BuscarPets(long id);
        /*
        Task AlterarDadosTutor(long id, Tutor tutor);*/


    }
}
