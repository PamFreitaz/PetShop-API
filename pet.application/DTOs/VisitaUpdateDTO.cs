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
        public Servicos? Servicos { get; set; }
        public long? PetId { get; set; }
        public decimal? Valor { get; set; }

        public VisitaUpdateDTO()
        {
            
        }

        public VisitaUpdateDTO(DateTime? data, Servicos? servicos, long? petId, decimal? valor)
        {
            Data = data;
            Servicos = servicos;
            PetId = petId;
            Valor = valor;
        }
    }
    

}
