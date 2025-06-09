using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;
using Alagaqui.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Alagaqui.Infrastructure.Data.Repositories
{
    public class TipoAlertaRepository : ITipoAlertaRepository
    {
        private readonly ApplicationContext _context;

        public TipoAlertaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<TipoAlertaEntity> ObterTodos()
        {
            return _context.TiposAlerta.ToList();
        }

        public TipoAlertaEntity? ObterPorId(int id)
        {
            return _context.TiposAlerta.Find(id);
        }

        public TipoAlertaEntity? Salvar(TipoAlertaEntity entity)
        {
            _context.TiposAlerta.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TipoAlertaEntity? Atualizar(TipoAlertaEntity entity)
        {
            var tipoExistente = _context.TiposAlerta.Find(entity.IdTipoAlerta);
            if (tipoExistente is null) return null;

            tipoExistente.DescricaoTipoAlerta = entity.DescricaoTipoAlerta;

            _context.TiposAlerta.Update(tipoExistente);
            _context.SaveChanges();

            return tipoExistente;
        }

        public TipoAlertaEntity? Deletar(int id)
        {
            var tipoExistente = _context.TiposAlerta.Find(id);
            if (tipoExistente is not null)
            {
                _context.TiposAlerta.Remove(tipoExistente);
                _context.SaveChanges();
                return tipoExistente;
            }
            return null;
        }

        public IEnumerable<TipoAlertaEntity> ObterTodosComAlertas()
        {
            return _context.TiposAlerta
                .Include(t => t.Alertas)
                .ToList();
        }
    }
}
