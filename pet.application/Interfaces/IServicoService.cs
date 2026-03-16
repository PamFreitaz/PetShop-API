using pet.Application.DTOs;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface IServicoService
    {
        Task AdicionarServico(Servico servico);
        Task <List<Servico>> Listar();
        Task AlterarServico(long id, ServicoUpdateDTO ServicoDTO);
        Task <Servico> BuscarServicoPorId(long id);
        Task DesativarServico (long id);
    }
}
