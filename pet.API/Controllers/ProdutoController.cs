using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        public readonly IProdutoService produtoService;
        public ProdutoController(IProdutoService produto)
        {
            produtoService = produto;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromBody] Produto produto)
        {
            await produtoService.CadastrarProduto(produto);
            return Ok("Produto Cadastrado com Sucesso");
        }

        [HttpGet("/listar/")]
        public async Task<IActionResult> Listar()
        {
            var listar = await produtoService.ListarProduto();
            return Ok(listar);
        }

        [HttpGet("/buscarporid/{id}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            var listar = await produtoService.BuscarProduto(id);
            return Ok(listar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(long id, ProdutoUpdateDTO produto)
        {
            await produtoService.AtualizarProduto(id, produto);
            return Ok("Produto atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(long id)
        {
            await produtoService.DeletarProduto(id);
            return Ok("Produto deletado com sucesso");
        }

        [HttpGet("buscarporcategoria/{id}")]
        public async Task<IActionResult>BuscarporCategoria(long id)
        {
            var categoria = await produtoService.ListarProdutoPorCategoria(id);
            return Ok(categoria);
        }
    }
}
