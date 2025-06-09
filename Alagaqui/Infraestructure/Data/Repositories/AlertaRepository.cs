using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;
using Alagaqui.Infrastructure.Data.AppData;

namespace Alagaqui.Infrastructure.Data.Repositories
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly ApplicationContext _context;

        public AlertaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<AlertaEntity> ObterTodos()
        {
            return _context.Alertas.ToList();
        }

        public AlertaEntity? ObterPorId(int id)
        {
            return _context.Alertas.Find(id);
        }

        public AlertaEntity? Salvar(AlertaEntity entity)
        {
            _context.Alertas.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public AlertaEntity? Atualizar(AlertaEntity entity)
        {
            var alertaExistente = _context.Alertas.Find(entity.IdAlerta);
            if (alertaExistente is null) return null;

            alertaExistente.IdOcorrenciaRelacionada = entity.IdOcorrenciaRelacionada;
            alertaExistente.IdTipoAlerta = entity.IdTipoAlerta;
            alertaExistente.MensagemAlerta = entity.MensagemAlerta;
            alertaExistente.DataHoraCriacaoAlerta = entity.DataHoraCriacaoAlerta;
            alertaExistente.ResolvidoAlerta = entity.ResolvidoAlerta;

            _context.Alertas.Update(alertaExistente);
            _context.SaveChanges();

            return alertaExistente;
        }

        public AlertaEntity? Deletar(int id)
        {
            var alertaExistente = _context.Alertas.Find(id);
            if (alertaExistente is not null)
            {
                _context.Alertas.Remove(alertaExistente);
                _context.SaveChanges();
                return alertaExistente;
            }
            return null;
        }
    }
}
