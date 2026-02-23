using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface IVisitaRepository
    {
        Task Adicionar(Visita visita);
        Task<List<Visita>> Listar();
        Task<Visita> BuscarPorId(long id);
        Task Atualizar(Visita visita);
        Task Cancelar(long id);
    }
}
