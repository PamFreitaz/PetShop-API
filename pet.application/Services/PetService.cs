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

        public Task<Pet> BuscarPorId(long id)
        {
            return repository.BuscarPorId(id);
        }

        public Task DesativarPet(long id)
        {
            return repository.Desativar(id);
        }

        public Task<List<Pet>> ListarPet()
        {
            return repository.Listar();
        }
    }
}
