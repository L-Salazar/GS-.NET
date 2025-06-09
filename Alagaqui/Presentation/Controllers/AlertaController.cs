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
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaApplicationService _applicationService;

        public AlertaController(IAlertaApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os alertas", Description = "Retorna todos os alertas registrados no sistema.")]
        [SwaggerResponse(200, "Lista obtida com sucesso", typeof(IEnumerable<AlertaEntity>))]
        [SwaggerResponse(204, "Nenhum alerta encontrado")]
        [SwaggerResponse(400, "Erro ao obter os dados")]
        [ProducesResponseType(typeof(IEnumerable<AlertaEntity>), 200)]
        public IActionResult Get()
        {
            try
            {
                var alertas = _applicationService.ObterTodosAlertas();
                if (alertas is null || !alertas.Any()) return NoContent();

                return Ok(alertas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um alerta específico", Description = "Retorna os detalhes de um alerta com base no ID informado.")]
        [SwaggerResponse(200, "Alerta encontrado com sucesso", typeof(AlertaEntity))]
        [SwaggerResponse(404, "Alerta não encontrado")]
        [SwaggerResponse(400, "Erro ao obter o alerta")]
        [ProducesResponseType(typeof(AlertaEntity), 200)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var alerta = _applicationService.ObterAlertaPorId(id);
                if (alerta is null) return NotFound();

                return Ok(alerta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo alerta", Description = "Cria um novo alerta com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Alerta criado com sucesso", typeof(AlertaEntity))]
        [SwaggerResponse(400, "Falha ao inserir o alerta")]
        [ProducesResponseType(typeof(AlertaEntity), 200)]
        public IActionResult Post([FromBody] AlertaDto entity)
        {
            try
            {
                var alerta = _applicationService.SalvarDadosAlerta(entity);
                return Ok(alerta);
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
        [SwaggerOperation(Summary = "Atualiza um alerta existente", Description = "Atualiza os dados de um alerta com base no ID fornecido.")]
        [SwaggerResponse(200, "Alerta atualizado com sucesso", typeof(AlertaEntity))]
        [SwaggerResponse(400, "Falha ao atualizar o alerta")]
        [ProducesResponseType(typeof(AlertaEntity), 200)]
        public IActionResult Put(int id, [FromBody] AlertaDto entity)
        {
            try
            {
                var alerta = _applicationService.EditarDadosAlerta(id, entity);
                return Ok(alerta);
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
        [SwaggerOperation(Summary = "Remove um alerta", Description = "Remove um alerta do sistema com base no ID informado.")]
        [SwaggerResponse(200, "Alerta removido com sucesso", typeof(AlertaEntity))]
        [SwaggerResponse(400, "Falha ao excluir o alerta")]
        [ProducesResponseType(typeof(AlertaEntity), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var alerta = _applicationService.DeletarDadosAlerta(id);
                return Ok(alerta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
