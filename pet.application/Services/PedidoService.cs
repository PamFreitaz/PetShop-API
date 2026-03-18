using pet.Application.DTOs;
using pet.Application.Handler;
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
        public readonly IDbConnectionFactory dbConnectionFactory;

        public PedidoService(IPedidoRepository repository, IProdutoRepository produto, IItemPedidoRepository itemPedido, IDbConnectionFactory db)
        {
            pedidoRepository = repository;
            produtoRepository = produto;
            itemPedidoRepository = itemPedido;
            dbConnectionFactory = db;
        }
        public async Task CriarPedido(PedidoCreateDTO pedidoDTO)
        {
            await PedidoUtil.ValidarPedido(pedidoDTO, produtoRepository);

            // abre UMA conexão para todas as operações
            using var connection = dbConnectionFactory.CreateOpenConnection();
            // inicia a transaction
            using var transaction = connection.BeginTransaction();

            try
            {
                //criando uma nova entidade para depois salvar no banco porque estava usando o PedidoCreateDTO
                var pedidoEntity = new Pedido
                {
                    TutorId = pedidoDTO.TutorId,                             //TutorId vem do DTO
                    StatusPedido = Domain.Enum.StatusPedido.PedidoEmAnalise, //StatusPedido estou setando para inicializar o pedido que vem do Enum StatusPedido e estabelecendo que todo pedido comece com o status em analise
                    DataCriacao = DateTime.Now,                              //DataCriacao setando sempre como a data atual
                    ValorTotal = 0,                                          //ValorTotal comecando com zero pois ainda nao pasou pelo foreach
                };

                //salvando no banco e recebendo o Id de volta (returning da query)
                var pedidoId = await pedidoRepository.Adicionar(pedidoEntity, connection, transaction);
                double Total = 0;

                //para cada item na lista roda uma nova iteração
                foreach (var item in pedidoDTO.ItensPedidos)
                {
                    var produto = await produtoRepository.Buscar(item.ProdutoId); //busca dados do produto com o id do itemPedidoDTO
                    var subTotal = produto.Valor * item.Quantidade;

                    int novoEstoque = produto.QuantidadeEstoque -= item.Quantidade;
                    await produtoRepository.DarBaixa(novoEstoque, produto.Id, connection, transaction);

                    var itemPedido = new ItemPedido
                    {
                        PedidoId = pedidoId,
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade,
                        ValorUnitario = produto.Valor,
                        Subtotal = subTotal,
                    };
                    //salva no banco um itemPedido (com Id do pedido Atual)
                    await itemPedidoRepository.Adicionar(itemPedido, connection, transaction);
                    //incrementa o subtotal
                    Total += subTotal;
                }
                //ao sair do foreach, atualizo o pedido q tava zerado com o valor atual
                await pedidoRepository.AtualizarTotal(pedidoId, Total, connection, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Aconteceu um erro ao gerar o seu pedido, tente novamente");
            }
        }
        public Task<Pedido> BuscarPedidoPorId(long id)
        {
            return pedidoRepository.BuscarPorId(id);
        }

        public Task<List<Pedido>> ListarPedidos()
        {
            return pedidoRepository.Listar();
        }

        public Task<List<Pedido>> ListarPedidosPorTutor(long id)
        {
            return pedidoRepository.ListarPorTutor(id);
        }
        public async Task MudarStatusPedido(long id, PedidoUpdateDTO pedidoDTO)
        {
            var mudarStatusExistente = await BuscarPedidoPorId(id);
            if (mudarStatusExistente == null)
            {
                throw new Exception("Pedido não encontrado");
            }
            if (pedidoDTO.StatusPedido.HasValue)
            {
                mudarStatusExistente.StatusPedido = pedidoDTO.StatusPedido.Value;
            }

            await pedidoRepository.MudarStatus(id, mudarStatusExistente);
        }

        public async Task AtualizarPedido(long id, PedidoUpdateDTO pedidoDTO)
        {
            var pedidoExistente = await BuscarPedidoPorId(id);
            PedidoUtil.PedidoExiste(pedidoExistente);
            await PedidoUtil.VerificarPedidoAtualizado(pedidoDTO, produtoRepository);

            if (pedidoDTO.StatusPedido.HasValue)
            {
                pedidoExistente.StatusPedido = pedidoDTO.StatusPedido.Value;
            }

            if (pedidoDTO.ValorTotal.HasValue)
            {
                pedidoExistente.ValorTotal = pedidoDTO.ValorTotal.Value;
            }
            using var connection = dbConnectionFactory.CreateOpenConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                if (pedidoDTO.ItensPedidos != null && pedidoDTO.ItensPedidos.Any())
                {
                    // agora o RemoverItensPedido está DENTRO da transaction
                    await itemPedidoRepository.RemoverItensPedido(id);

                    double novoTotal = 0;
                    foreach (var itemDTO in pedidoDTO.ItensPedidos)
                    {
                        var produto = await produtoRepository.Buscar(itemDTO.ProdutoId);
                        var subTotal = produto.Valor * itemDTO.Quantidade;

                        var itemPedido = new ItemPedido
                        {
                            PedidoId = id,
                            ProdutoId = itemDTO.ProdutoId,
                            Quantidade = itemDTO.Quantidade,
                            ValorUnitario = produto.Valor,
                            Subtotal = subTotal,
                        };

                        await itemPedidoRepository.Adicionar(itemPedido, connection, transaction);
                        novoTotal += subTotal;
                    }
                }

                await pedidoRepository.Atualizar(id, pedidoExistente);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw new Exception("Erro ao atualizar o pedido, tente novamente");
            }
        }

        public Task CancelarPedido(long id)
        {
            return pedidoRepository.Cancelar(id);
        }
        
    }
}
