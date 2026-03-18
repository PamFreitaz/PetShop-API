using pet.Application.DTOs;
using pet.Domain.Entity;
using pet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Handler
{
    public class PedidoUtil
    {
        public async static Task ValidarPedido(PedidoCreateDTO pedidoDTO, IProdutoRepository produtoRepository)
        {
            //se o pedido for nullo ou menor que 1, vai dar o erro de Pedido tem que ter algum item
            if (pedidoDTO.ItensPedidos == null || pedidoDTO.ItensPedidos.Count < 1)
            {
                throw new Exception("Pedido tem que ter algum item");
            }
            if (pedidoDTO.TutorId <= 0)
                throw new Exception("Tutor inválido");

            foreach (var item in pedidoDTO.ItensPedidos)
            {
                if (item.Quantidade <= 0)
                    throw new Exception("A quantidade deve ser maior que zero");

                var produto = await produtoRepository.Buscar(item.ProdutoId);
                if (produto == null)
                    throw new Exception($"Produto {item.ProdutoId} não encontrado!");
                if (produto.QuantidadeEstoque < item.Quantidade)
                    throw new Exception($"Estoque insuficiente para o produto {produto.Nome}. Disponível: {produto.QuantidadeEstoque}");
            }
        }
        public static void PedidoExiste(Pedido pedido)
        {
            if (pedido == null)
                throw new Exception("Pedido não encontrado");
        }
        public async static Task VerificarPedidoAtualizado(PedidoUpdateDTO pedidoDTO, IProdutoRepository produtoRepository)
        {
            // valida estoque antes de abrir a transaction
            if (pedidoDTO.ItensPedidos != null && pedidoDTO.ItensPedidos.Count > 0)
            {
                foreach (var item in pedidoDTO.ItensPedidos)
                {
                    var produto = await produtoRepository.Buscar(item.ProdutoId);
                    if (produto == null)
                        throw new Exception($"Produto {item.ProdutoId} não encontrado!");
                    if (produto.QuantidadeEstoque < item.Quantidade)
                        throw new Exception($"Estoque insuficiente para {produto.Nome}. Disponível: {produto.QuantidadeEstoque}");
                }
            }
        }
    }
}
