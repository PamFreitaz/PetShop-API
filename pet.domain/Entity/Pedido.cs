using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Pedido
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public double ValorTotal { get; set; }
        public List<ItemPedido> ItensPedidos { get; set; } = new();
        public StatusPedido StatusPedido { get; set; }
        public long TutorId { get; set; }

        public Pedido()
        {
            
        }

        public Pedido(long id, DateTime dataCriacao, double valorTotal, List<ItemPedido> itensPedidos, StatusPedido statusPedido, long tutorId)
        {
            Id = id;
            DataCriacao = dataCriacao;
            ValorTotal = valorTotal;
            ItensPedidos = itensPedidos;
            StatusPedido = statusPedido;
            TutorId = tutorId;
        }
    }
}
