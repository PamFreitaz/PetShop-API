using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Visita
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Servicos Servicos { get; set; }
        public long PetId { get; set; }
        public double Valor { get; set; }
        public StatusVisita StatusVisita { get; set; }


        public Visita()
        {
        }

        public Visita(int id, DateTime data, Servicos servicos, long petId, double valor, StatusVisita statusVisita)
        {
            Id = id;
            Data = data;
            Servicos = servicos;
            PetId = petId;
            Valor = valor;
            StatusVisita = statusVisita;
        }
    }
}
