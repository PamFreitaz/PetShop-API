using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface IServicoRepository
    {
        Task<Servico>BuscarPorId(long id);
        Task Adicionar(Servico servico);
        Task<List<Servico>> Listar();
        Task Alterar(long id, Servico servico);
        Task Desativar(long id);
    }
}
