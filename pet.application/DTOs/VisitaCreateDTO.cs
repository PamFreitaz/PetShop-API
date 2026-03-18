using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class VisitaCreateDTO
    {
        public DateTime Data { get; set; }
        public long ServicoId { get; set; }
        public long PetId { get; set; }

        public VisitaCreateDTO() 
        {

        }

        public VisitaCreateDTO(DateTime data, long servicoId, long petId)
        {
            Data = data;
            ServicoId = servicoId;
            PetId = petId;
        }
    }
}