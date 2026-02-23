using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class PetCreateDTO
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public long TutorId { get; set; }
        public Especie Especie { get; set; }
        public Porte? Porte { get; set; }
        public string? Raca { get; set; }
        public string? Cor { get; set; }

        public PetCreateDTO()
        {
            
        }

        public PetCreateDTO(long id, string nome, DateTime dataNascimento, long tutorId, Especie especie, Porte? porte, string? raca, string? cor)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            TutorId = tutorId;
            Especie = especie;
            Porte = porte;
            Raca = raca;
            Cor = cor;
        }
    }
}
