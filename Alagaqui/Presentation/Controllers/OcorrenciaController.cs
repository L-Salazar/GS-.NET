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
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaApplicationService _applicationService;

        public OcorrenciaController(IOcorrenciaApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as ocorrências", Description = "Retorna todas as ocorrências cadastradas.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<OcorrenciaEntity>))]
        [SwaggerResponse(204, "Nenhuma ocorrência encontrada")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<OcorrenciaEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var ocorrencias = _applicationService.ObterTodasOcorrencias();
                if (ocorrencias is null || !ocorrencias.Any()) return NoContent();

                return Ok(ocorrencias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma ocorrência específica", Description = "Retorna os detalhes de uma ocorrência com base no ID.")]
        [SwaggerResponse(200, "Ocorrência encontrada com sucesso", typeof(OcorrenciaEntity))]
        [SwaggerResponse(404, "Ocorrência não encontrada")]
        [SwaggerResponse(400, "Erro ao obter a ocorrência")]
        [ProducesResponseType(typeof(OcorrenciaEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var ocorrencia = _applicationService.ObterOcorrenciaPorId(id);
                if (ocorrencia is null) return NotFound();

                return Ok(ocorrencia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova ocorrência", Description = "Cria uma nova ocorrência com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Ocorrência criada com sucesso", typeof(OcorrenciaEntity))]
        [SwaggerResponse(400, "Falha ao inserir a ocorrência")]
        [ProducesResponseType(typeof(OcorrenciaEntity), 200)]
        public IActionResult Post([FromBody] OcorrenciaDto entity)
        {
            try
            {
                var ocorrencia = _applicationService.SalvarDadosOcorrencia(entity);
                return Ok(ocorrencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma ocorrência", Description = "Atualiza os dados de uma ocorrência existente com base no ID.")]
        [SwaggerResponse(200, "Ocorrência atualizada com sucesso", typeof(OcorrenciaEntity))]
        [SwaggerResponse(400, "Erro ao atualizar a ocorrência")]
        [ProducesResponseType(typeof(OcorrenciaEntity), 200)]
        public IActionResult Put(int id, [FromBody] OcorrenciaDto entity)
        {
            try
            {
                var ocorrencia = _applicationService.EditarDadosOcorrencia(id, entity);
                return Ok(ocorrencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui uma ocorrência", Description = "Remove uma ocorrência com base no ID fornecido.")]
        [SwaggerResponse(200, "Ocorrência removida com sucesso", typeof(OcorrenciaEntity))]
        [SwaggerResponse(400, "Erro ao excluir a ocorrência")]
        [ProducesResponseType(typeof(OcorrenciaEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var ocorrencia = _applicationService.DeletarDadosOcorrencia(id);
                return Ok(ocorrencia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
