using pet.Application.DTOs;
using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface IVisitaService
    {
        Task AdicionarVisita (VisitaCreateDTO visita);
        Task<List<Visita>> ListarVista();
        Task<Visita> BuscarVisitaPorId(long id);
        Task AtualizarVisita(VisitaUpdateDTO visita);
        Task CancelarVisita(long id);
    }
}
