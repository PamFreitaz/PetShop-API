using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Categoria
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Categoria()
        {
            
        }
        public Categoria(long id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
