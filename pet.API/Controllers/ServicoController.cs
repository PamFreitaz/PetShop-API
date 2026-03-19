using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pet.Application.DTOs;
using pet.Application.Interfaces;
using pet.Domain.Entity;

namespace pet.API.Controllers
{
    [ApiController]
    [Route("servico")]
    [Authorize(Roles = "Admin")]
    public class ServicoController : ControllerBase
    {
        public readonly IServicoService servicoService;

        public ServicoController(IServicoService Service)
        {
            servicoService = Service;
        }

        /// <summary>
        /// Listar todos os serviços do sistema
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var lista = await servicoService.Listar();
            return Ok(lista);
        }

        /// <summary>
        /// Buscar um serviço específico por Id
        /// </summary>
        /// <param name="id"> Id do serviço</param>
        /// <returns>Retorna um serviço específico</returns>
        [HttpGet("buscarporid/{id}")]
        public async Task <IActionResult>ListarPorID(long id)
        {
            var busca = await servicoService.BuscarServicoPorId(id);
            return Ok(busca);
        }

        ///<summary>
        ///Adiciona um novo servico disponivel no sistema
        ///</summary>
        [HttpPost]
        public async Task<IActionResult> CadastrarServico([FromBody] Servico servico)
        {
            await servicoService.AdicionarServico(servico);
            return Ok("Serviço adicionado com sucesso");
        }

        /// <summary>
        /// Atualiza o serviço disponivel no sistema
        /// </summary>
        /// <param name="id"> id do serviço a ser atualizado</param>
        /// <param name="DTO"> informações da atualização a ser realizada</param>
        
        [HttpPut]
        public async Task<IActionResult> AlterarServico(long id, ServicoUpdateDTO DTO)
        {
            await servicoService.AlterarServico(id, DTO);
            return Ok("Serviço atualizado com sucesso");
        }

        /// <summary>
        /// Desativar um serviço do catálago
        /// </summary>
        /// <param name="id">id do serviço a ser desativado</param>
        /// <returns>mensagem de sucesso</returns>
        [HttpDelete]
        public async Task<IActionResult> Deletar(long id)
        {
            await servicoService.DesativarServico(id);
            return Ok("Serviço desativado com sucesso");
        }
    }
}
