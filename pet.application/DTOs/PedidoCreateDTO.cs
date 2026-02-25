using pet.Domain.Entity;
using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class PedidoCreateDTO
    {
        public List<ItemPedidoDTO> ItensPedidos { get; set; } = new();
        public long TutorId { get; set; }
        public PedidoCreateDTO()
        {
            
        }

        public PedidoCreateDTO(List<ItemPedidoDTO> itensPedidos, long tutorId)
        {
            ItensPedidos = itensPedidos;
            TutorId = tutorId;
        }
    }
}
