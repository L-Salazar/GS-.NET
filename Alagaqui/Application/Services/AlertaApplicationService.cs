using Alagaqui.Application.Dtos;
using Alagaqui.Application.Interfaces;
using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;

namespace Alagaqui.Application.Services
{
    public class AlertaApplicationService : IAlertaApplicationService
    {
        private readonly IAlertaRepository _alertaRepository;

        public AlertaApplicationService(IAlertaRepository alertaRepository)
        {
            _alertaRepository = alertaRepository;
        }

        public IEnumerable<AlertaEntity> ObterTodosAlertas()
        {
            return _alertaRepository.ObterTodos();
        }

        public AlertaEntity? ObterAlertaPorId(int id)
        {
            return _alertaRepository.ObterPorId(id);
        }

        public AlertaEntity? SalvarDadosAlerta(AlertaDto dto)
        {
            var novoAlerta = new AlertaEntity
            {
                IdOcorrenciaRelacionada = dto.IdOcorrenciaRelacionada,
                IdTipoAlerta = dto.IdTipoAlerta,
                MensagemAlerta = dto.MensagemAlerta,
                DataHoraCriacaoAlerta = dto.DataHoraCriacaoAlerta,
                ResolvidoAlerta = dto.ResolvidoAlerta
            };

            return _alertaRepository.Salvar(novoAlerta);
        }

        public AlertaEntity? EditarDadosAlerta(int id, AlertaDto dto)
        {
            var alertaAtualizado = new AlertaEntity
            {
                IdAlerta = id,
                IdOcorrenciaRelacionada = dto.IdOcorrenciaRelacionada,
                IdTipoAlerta = dto.IdTipoAlerta,
                MensagemAlerta = dto.MensagemAlerta,
                DataHoraCriacaoAlerta = dto.DataHoraCriacaoAlerta,
                ResolvidoAlerta = dto.ResolvidoAlerta
            };

            return _alertaRepository.Atualizar(alertaAtualizado);
        }

        public AlertaEntity? DeletarDadosAlerta(int id)
        {
            return _alertaRepository.Deletar(id);
        }
    }
}
