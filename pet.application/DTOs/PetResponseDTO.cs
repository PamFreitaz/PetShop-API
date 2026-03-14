using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.DTOs
{
    public class PetResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public long TutorId { get; set; }
        public Especie Especie { get; set; }
        public bool Ativo { get; set; }
        public Porte? Porte { get; set; }
        public string? Raca { get; set; }
        public string? Cor { get; set; }

        public PetResponseDTO()
        {
            
        }

        public PetResponseDTO(long id, string nome, DateTime dataNascimento, long tutorId, Especie especie, bool ativo, Porte? porte, string? raca, string? cor)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            TutorId = tutorId;
            Especie = especie;
            Ativo = ativo;
            Porte = porte;
            Raca = raca;
            Cor = cor;
        }
    }
}
