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
    public class TipoAlertaController : ControllerBase
    {
        private readonly ITipoAlertaApplicationService _applicationService;

        public TipoAlertaController(ITipoAlertaApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os tipos de alerta", Description = "Retorna uma lista de todos os tipos de alerta disponíveis.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<TipoAlertaEntity>))]
        [SwaggerResponse(204, "Nenhum tipo de alerta encontrado")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<TipoAlertaEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var tipos = _applicationService.ObterTodosTiposAlerta();
                if (tipos is null || !tipos.Any()) return NoContent();

                return Ok(tipos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um tipo de alerta", Description = "Retorna os dados de um tipo de alerta específico com base no ID informado.")]
        [SwaggerResponse(200, "Tipo de alerta encontrado", typeof(TipoAlertaEntity))]
        [SwaggerResponse(404, "Tipo de alerta não encontrado")]
        [SwaggerResponse(400, "Erro ao obter o tipo de alerta")]
        [ProducesResponseType(typeof(TipoAlertaEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var tipo = _applicationService.ObterTipoAlertaPorId(id);
                if (tipo is null) return NotFound();

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo tipo de alerta", Description = "Cria um novo tipo de alerta com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Tipo de alerta criado com sucesso", typeof(TipoAlertaEntity))]
        [SwaggerResponse(400, "Falha ao inserir o tipo de alerta")]
        [ProducesResponseType(typeof(TipoAlertaEntity), 200)]
        public IActionResult Post([FromBody] TipoAlertaDto entity)
        {
            try
            {
                var tipo = _applicationService.SalvarDadosTipoAlerta(entity);
                return Ok(tipo);
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
        [SwaggerOperation(Summary = "Atualiza um tipo de alerta", Description = "Atualiza os dados de um tipo de alerta existente com base no ID.")]
        [SwaggerResponse(200, "Tipo de alerta atualizado com sucesso", typeof(TipoAlertaEntity))]
        [SwaggerResponse(400, "Erro ao atualizar o tipo de alerta")]
        [ProducesResponseType(typeof(TipoAlertaEntity), 200)]
        public IActionResult Put(int id, [FromBody] TipoAlertaDto entity)
        {
            try
            {
                var tipo = _applicationService.EditarDadosTipoAlerta(id, entity);
                return Ok(tipo);
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
        [SwaggerOperation(Summary = "Exclui um tipo de alerta", Description = "Remove um tipo de alerta do sistema com base no ID informado.")]
        [SwaggerResponse(200, "Tipo de alerta removido com sucesso", typeof(TipoAlertaEntity))]
        [SwaggerResponse(400, "Erro ao excluir o tipo de alerta")]
        [ProducesResponseType(typeof(TipoAlertaEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var tipo = _applicationService.DeletarDadosTipoAlerta(id);
                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("com-alertas")]
        [SwaggerOperation(
    Summary = "Lista todos os tipos de alerta com seus alertas",
    Description = "Retorna todos os tipos de alerta cadastrados, incluindo os alertas associados a cada tipo."
)]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<TipoAlertaEntity>))]
        [SwaggerResponse(204, "Nenhum tipo de alerta encontrado")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<TipoAlertaEntity>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetComAlertas()
        {
            try
            {
                var tipos = _applicationService.ObterTiposComAlertas();
                if (tipos is null || !tipos.Any()) return NoContent();

                return Ok(tipos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
