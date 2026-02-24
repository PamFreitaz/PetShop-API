using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Entity
{
    public class Pet
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public long TutorId { get; set; }
        public Especie Especie { get; set; }
        public bool Ativo {  get; set; }
        
        public Pet()
        {
            
        }

        public Pet(long id, string nome, DateTime dataNascimento, long tutorId, Especie especie, bool ativo)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            TutorId = tutorId;
            Especie = especie;
            Ativo = ativo;
            
        }
        //forma de abstração sem obrigatoriedade
        public virtual double MultiplicadorDePorte()
        {
            throw new Exception("Tipo de pet não suporta cálculo");
        }
    }
}
