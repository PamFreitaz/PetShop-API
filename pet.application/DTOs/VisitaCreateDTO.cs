using pet.Domain.Enum;
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
        public Servicos Servicos { get; set; }
        public long PetId { get; set; }
    }
}
