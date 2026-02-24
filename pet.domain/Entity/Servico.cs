using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Servico
    {
        public long Id {  get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Servico()
        {
            
        }

        public Servico(long id, string nome, double preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }
}
