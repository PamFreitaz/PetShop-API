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

        
    }

    
}
