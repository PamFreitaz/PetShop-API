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
        public readonly IServicoRepository ServicoRepository;
        public VisitaService(IVisitaRepository repository, IPetRepository petRepository, IServicoRepository servicoRepository)
        {
            VisitaRepository = repository;
            PetRepository = petRepository;
            ServicoRepository = servicoRepository;
        }
        public async Task AdicionarVisita(VisitaCreateDTO visita)
        {   //uso o metodo BuscarPorId do PetRepository para me trazer as informações do Pet
            var pet = await PetRepository.BuscarPorId(visita.PetId);
            //uso o metodo BuscarPorIa do ServicoRepository para trazer a informação do enum servicos, por isso o (int)
            var servico = await ServicoRepository.BuscarPorId((int)visita.Servicos);

            double Multiplicador = pet.MultiplicadorDePorte();


            double valor = servico.Preco * Multiplicador;

            var visitaEntity = new Visita
            {

                Data = visita.Data,
                Servicos = visita.Servicos,
                PetId = visita.PetId,
                Valor = valor,
                //toda vez que criar uma visita vai setar como agendado
                StatusVisita = StatusVisita.Agendado,
            };
            await VisitaRepository.Adicionar(visitaEntity);

        }

        public async Task AtualizarVisita(long id, VisitaUpdateDTO visita)
        {
            var visitaExistente = await BuscarVisitaPorId(id);

            if (visitaExistente == null)
            {
                throw new Exception("Visita não encontrada");
            }  
            if (visita.Data.HasValue)
            {
                visitaExistente.Data = visita.Data.Value;
            }
            if (visita.Servicos.HasValue)
            {
                visitaExistente.Servicos = visita.Servicos.Value;
            }
            if (visita.PetId.HasValue)
            {
                visitaExistente.PetId = visita.PetId.Value;
            }
            if (visita.Valor.HasValue)
            {
                visitaExistente.Valor = visita.Valor.Value;
            }
            if (visita.statusVisita.HasValue)
            {
                visitaExistente.StatusVisita = visita.statusVisita.Value;
            }
            await VisitaRepository.Atualizar(visitaExistente);
                         

        }

        public Task<Visita> BuscarVisitaPorId(long id)
        {
            return VisitaRepository.BuscarPorId(id);
        }

        public async Task CancelarVisita(long id)
        {
            var visita = await BuscarVisitaPorId(id);

            if (visita == null)
            {
                throw new Exception("Visita não encontrada.");
            }

            if (visita.StatusVisita != StatusVisita.Agendado)
            {
                throw new Exception($"Não é possível cancelar essa visita, o status atual dessa visita é: {visita.StatusVisita}");
            }
            await VisitaRepository.Cancelar(id);
        }

        public Task<List<Visita>> ListarVisita()
        {
            return VisitaRepository.Listar();
        }
        public Task FinalizarVisita(long id)
        {
            return VisitaRepository.Finalizar(id);
        }
    }
}
