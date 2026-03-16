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
    public class ServicoService : IServicoService

    {

        public readonly IServicoRepository servicoRepository;

        public ServicoService(IServicoRepository servico)
        {
            servicoRepository = servico;
        }

        public Task AdicionarServico(Servico servico)
        {
            return servicoRepository.Adicionar(servico);
        }

        public async Task AlterarServico(long id, ServicoUpdateDTO ServicoDTO)
        {
            var servico = await BuscarServicoPorId(id);

            if (ServicoDTO.Nome != null)
            {
                servico.Nome = ServicoDTO.Nome;
            }
            if (ServicoDTO.Descricao != null)
            {
                servico.Descricao = ServicoDTO.Descricao;
            }
            if (ServicoDTO.Preco.HasValue)
            {
                servico.Preco = ServicoDTO.Preco.Value;
            }
            if (ServicoDTO.Ativo.HasValue)
            {
                servico.Ativo = ServicoDTO.Ativo.Value;
            }
            await servicoRepository.Alterar(id,servico);
        }

        public Task <Servico> BuscarServicoPorId(long id)
        {
            return servicoRepository.BuscarPorId(id);
        }

        public Task DesativarServico(long id)
        {
            return servicoRepository.Desativar(id);
        }

        public Task <List<Servico>> Listar()
        {
            return servicoRepository.Listar();
        }
    }
}
