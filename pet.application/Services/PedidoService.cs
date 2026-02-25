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
    public class PedidoService : IPedidoService
    {

        public readonly IPedidoRepository pedidoRepository;
        public readonly IProdutoRepository produtoRepository;
        public readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoService(IPedidoRepository repository, IProdutoRepository produto, IItemPedidoRepository itemPedido)
        {
            pedidoRepository = repository;
            produtoRepository = produto;
            itemPedidoRepository = itemPedido;
        }

        public async Task CriarPedido(PedidoCreateDTO pedidoDTO)
        {
            //se o pedido for nullo ou menor que 1, vai dar o erro de Pedido tem que ter algum item
            if(pedidoDTO.ItensPedidos == null || pedidoDTO.ItensPedidos.Count < 1)
            {
                throw new Exception("Pedido tem que ter algum item");
            }

            //criando uma nova entidade para depois salvar no banco porque estava usando o PedidoCreateDTO
            var pedidoEntity = new Pedido
            {   
                
                TutorId = pedidoDTO.TutorId,                             //TutorId vem do DTO
                StatusPedido = Domain.Enum.StatusPedido.PedidoEmAnalise, //StatusPedido estou setando para inicializar o pedido que vem do Enum StatusPedido e estabelecendo que todo pedido comece com o status em analise
                DataCriacao = DateTime.Now,                              //DataCriacao setando sempre como a data atual
                ValorTotal = 0,                                          //ValorTotal comecando com zero pois ainda nao pasou pelo foreach
            };

            //salvando no banco e recebendo o Id de volta (returning da query)
            var pedidoId = await pedidoRepository.Adicionar(pedidoEntity);
            double Total = 0;

            //para cada item na lista roda uma nova iteração
            foreach (var item in pedidoDTO.ItensPedidos)
            {
                var produto = await produtoRepository.Buscar(item.ProdutoId); //busca dados do produto com o id do itemPedidoDTO
                var subTotal = produto.Valor * item.Quantidade;

                var itemPedido = new ItemPedido
                {
                    PedidoId = pedidoId,
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    ValorUnitario = produto.Valor,
                    Subtotal = subTotal,
                };
                //salva no banco um itemPedido (com Id do pedido Atual)
                await itemPedidoRepository.Adicionar(itemPedido);
                //incrementa o subtotal
                Total += subTotal;
            }
            //ao sair do foreach, atualizo o pedido q tava zerado com o valor atual
            await pedidoRepository.AtualizarTotal(pedidoId, Total);
            
        }
    }
}
