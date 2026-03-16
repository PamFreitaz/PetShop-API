using pet.Application.DTOs;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface IPetService
    {
        Task AdicionarPet (PetCreateDTO pet);
        Task <List<PetResponseDTO>> ListarPet();
        Task DesativarPet(long id);
        Task <PetResponseDTO> BuscarPorId (long id);
        Task <List<PetResponseDTO>> ListarPetsAtivos(); 
        
        
    }
}
