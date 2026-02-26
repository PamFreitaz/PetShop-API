using pet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task <long>Adicionar(Pedido pedido);
        Task AtualizarTotal (long PedidoId, double Total);
        Task<Pedido> BuscarPorId(long id);
        Task<List<Pedido>> Listar();
        Task<List<Pedido>> ListarPorTutor(long id);
        Task Atualizar(long id, Pedido pedido);
        Task Cancelar(long id);
        Task MudarStatus(long id, Pedido pedido);

    }
}
