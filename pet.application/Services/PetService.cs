using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using pet.Domain.Enum;
using pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository repository;
        public PetService(IPetRepository PetRepository)
        {
            repository = PetRepository;
        }
        public Task AdicionarPet(PetCreateDTO pet)
        {
            if (pet.Especie == Especie.Cachorro)
            {
                var petEntity = new Cachorro
                {
                    Nome = pet.Nome,
                    DataNascimento = pet.DataNascimento,
                    TutorId = pet.TutorId,
                    Especie = pet.Especie,
                    Porte = pet.Porte.Value,
                    Raca = pet.Raca,
                    Cor = pet.Cor,
                    Ativo = true,
                };
                return repository.AdicionarCachorro(petEntity);
            }

            if (pet.Especie == Especie.Gato)
            {
                var petEntity = new Gato
                {
                    Nome = pet.Nome,
                    DataNascimento = pet.DataNascimento,
                    TutorId = pet.TutorId,
                    Especie = pet.Especie,
                    Raca = pet.Raca,
                    Cor = pet.Cor,
                    Ativo = true,
                };
                return repository.AdicionarGato(petEntity);
            }
            else
            {
                throw new("Só aceitamos cachorro e gato no momento");
            }

        }

        public async Task<PetResponseDTO> BuscarPorId(long id)
        {
            var pet = await repository.BuscarPorId(id);
            return ConverterParaDTO(pet);
        }

        public Task DesativarPet(long id)
        {
            return repository.Desativar(id);
        }

        public async Task<List<PetResponseDTO>> ListarPet()
        {
            var pets = await repository.Listar();
            return pets.Select(ConverterParaDTO).ToList();
        }
        public async Task<List<PetResponseDTO>> ListarPetsAtivos()
        {
            var pets = await repository.ListarAtivos();
            return pets.Select(ConverterParaDTO).ToList();
        }

        private PetResponseDTO ConverterParaDTO(Pet pet)
        {
            return new PetResponseDTO
            {
                Id = pet.Id,
                Nome = pet.Nome,
                DataNascimento = pet.DataNascimento,
                TutorId = pet.TutorId,
                Especie = pet.Especie,
                Ativo = pet.Ativo,
                Porte = pet is Cachorro cachorro ? cachorro.Porte : null,
                Raca = pet is Cachorro c ? c.Raca : (pet is Gato gato ? gato.Raca : null),
                Cor = pet is Cachorro c2 ? c2.Cor : (pet is Gato g2 ? g2.Cor : null),
            };
        }
    }
}
