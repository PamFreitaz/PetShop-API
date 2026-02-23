using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;
using pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Services
{
    public class TutorService : ITutorService
    {
        public readonly ITutorRepository repository;
        public TutorService(ITutorRepository tutorRepository)
        {
            repository = tutorRepository;
        }
        public Task CadastrarTutor(TutorCreateDTO tutor)
        {
            var DataCriacao = DateTime.Now;
            var TutorEntity = new Tutor
            {
                Nome = tutor.Nome,
                Cpf = tutor.Cpf,
                Email = tutor.Email,
                Telefone = tutor.Telefone,
                DataNascimento = tutor.DataNascimento,
                DataCadastro = DataCriacao
            };
            return repository.Cadastrar(TutorEntity);
        }

        public Task<List<Tutor>> ListarTutores()
        {
            return repository.Listar();
        }

        public Task <Tutor> BuscarPorId(long id)
        {
            return repository.BuscarPorId(id);
        }
        public Task<List<Pet>> BuscarPets(long id)
        {
            return repository.BuscarPets(id);
        }

        /*public Task AlterarDadosTutor(long id, Tutor tutor)
        {
            
        }*/



    }
}
