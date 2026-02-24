using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Cachorro : Pet
    {
        public Porte Porte { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }

        public Cachorro()
        {
            
        }
        public Cachorro(long id, string nome, DateTime dataNascimento, long tutorId, Especie especie, bool ativo, Porte porte, string raca, string cor)
            : base(id, nome, dataNascimento, tutorId, especie, ativo)
        {
            Porte = porte;
            Raca = raca;
            Cor = cor;
        }
        //sobrescrevendo
        public override double MultiplicadorDePorte()
        {

            if (Porte == Porte.Pequeno)
            {
                return 1.0;
            }
            else if (Porte == Porte.Medio)
            {
                return 1.25;
            }
            else if (Porte == Porte.Grande)
            {
                return 1.50;
            }
            else
            {
                return 0;
            }
        }
    }
}
