using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Gato : Pet
    {
        public string Raca { get; set; }
        public string Cor { get; set; }

        public Gato()
        {
            
        }
        public Gato(long id, string nome, DateTime dataNascimento, long tutorId, Especie especie, bool ativo, string raca, string cor)
            : base(id, nome, dataNascimento, tutorId, especie, ativo)
        {
            Raca = raca;
            Cor = cor;
        }

        public Gato(string raca, string cor)
        {
            Raca = raca;
            Cor = cor;
        }

        //sobrescrevendo
        public override double MultiplicadorDePorte()
        {
            return 1.20;
        }
    }

    
}
