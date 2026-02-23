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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pet.Application.Services
{
    public class VisitaService : IVisitaService
    {
        public readonly IVisitaRepository VisitaRepository;
        public readonly IPetRepository PetRepository;
        public VisitaService(IVisitaRepository repository, IPetRepository petRepository)
        {
            VisitaRepository = repository;
            PetRepository = petRepository;
        }
        public async Task AdicionarVisita(VisitaCreateDTO visita)
        {   //uso o metodo BuscarPorId do PetRepository para me trazer as informações do Pet
            var pet = await PetRepository.BuscarPorId(visita.PetId);

            double valor = 0;

            if (pet.Porte == Porte.Pequeno)
            {
                valor = (double)visita.Servicos;
            }
            else if (pet.Porte == Porte.Medio)
            {
                valor = (double)visita.Servicos * 1.10;
            }
            else if (pet.Porte == Porte.Grande)
            {
                valor = (double)visita.Servicos * 1.25;
            }
            var visitaEntity = new Visita
            {

                Data = visita.Data,
                Servicos = visita.Servicos,
                PetId = visita.PetId,
                Valor = valor,
            };
            await VisitaRepository.Adicionar(visitaEntity);

        }

        public Task AtualizarVisita(VisitaUpdateDTO visita)
        {
            throw new NotImplementedException();
        }

        public Task<Visita> BuscarVisitaPorId(long id)
        {
            return VisitaRepository.BuscarPorId(id);
        }

        public Task CancelarVisita(long id)
        {
            return VisitaRepository.Cancelar(id);
        }

        public Task<List<Visita>> ListarVista()
        {
            return VisitaRepository.Listar();
        }
    }
}
