using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs

{
    public class VisitaUpdateDTO
    {
        public DateTime? Data { get; set; }
        public long? ServicoId { get; set; }
        public long? PetId { get; set; }
        public double? Valor { get; set; }
        public StatusVisita? StatusVisita { get; set; }

        public VisitaUpdateDTO()
        {
            
        }

        public VisitaUpdateDTO(DateTime? data, long? servicoId, long? petId, double? valor, StatusVisita? statusVisita)
        {
            Data = data;
            ServicoId = servicoId;
            PetId = petId;
            Valor = valor;
            StatusVisita = statusVisita;
        }
    }
    

}
