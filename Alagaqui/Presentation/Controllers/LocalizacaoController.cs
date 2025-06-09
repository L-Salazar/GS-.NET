using Alagaqui.Application.Dtos;
using Alagaqui.Application.Interfaces;
using Alagaqui.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Alagaqui.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private readonly ILocalizacaoApplicationService _applicationService;

        public LocalizacaoController(ILocalizacaoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as localizações", Description = "Retorna uma lista de todas as localizações cadastradas.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<LocalizacaoEntity>))]
        [SwaggerResponse(204, "Nenhuma localização encontrada")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<LocalizacaoEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var localizacoes = _applicationService.ObterTodasLocalizacoes();
                if (localizacoes is null || !localizacoes.Any()) return NoContent();

                return Ok(localizacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma localização específica", Description = "Retorna os detalhes de uma localização com base no ID informado.")]
        [SwaggerResponse(200, "Localização encontrada com sucesso", typeof(LocalizacaoEntity))]
        [SwaggerResponse(404, "Localização não encontrada")]
        [SwaggerResponse(400, "Erro ao obter a localização")]
        [ProducesResponseType(typeof(LocalizacaoEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var localizacao = _applicationService.ObterLocalizacaoPorId(id);
                if (localizacao is null) return NotFound();

                return Ok(localizacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova localização", Description = "Cria uma nova localização com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Localização criada com sucesso", typeof(LocalizacaoEntity))]
        [SwaggerResponse(400, "Falha ao inserir a localização")]
        [ProducesResponseType(typeof(LocalizacaoEntity), 200)]
        public IActionResult Post([FromBody] LocalizacaoDto entity)
        {
            try
            {
                var localizacao = _applicationService.SalvarDadosLocalizacao(entity);
                return Ok(localizacao);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma localização existente", Description = "Atualiza os dados de uma localização com base no ID fornecido.")]
        [SwaggerResponse(200, "Localização atualizada com sucesso", typeof(LocalizacaoEntity))]
        [SwaggerResponse(400, "Falha para atualizar a localização")]
        [ProducesResponseType(typeof(LocalizacaoEntity), 200)]
        public IActionResult Put(int id, [FromBody] LocalizacaoDto entity)
        {
            try
            {
                var localizacao = _applicationService.EditarDadosLocalizacao(id, entity);
                return Ok(localizacao);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma localização existente", Description = "Remove os dados de uma localização com base no ID fornecido.")]
        [SwaggerResponse(200, "Localização removida com sucesso", typeof(LocalizacaoEntity))]
        [SwaggerResponse(400, "Falha ao excluir a localização")]
        [ProducesResponseType(typeof(LocalizacaoEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var localizacao = _applicationService.DeletarDadosLocalizacao(id);
                return Ok(localizacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
