using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;
using Alagaqui.Infrastructure.Data.AppData;

namespace Alagaqui.Infrastructure.Data.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly ApplicationContext _context;

        public LocalizacaoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<LocalizacaoEntity> ObterTodos()
        {
            return _context.Localizacoes.ToList();
        }

        public LocalizacaoEntity? ObterPorId(int id)
        {
            return _context.Localizacoes.Find(id);
        }

        public LocalizacaoEntity? Salvar(LocalizacaoEntity entity)
        {
            _context.Localizacoes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public LocalizacaoEntity? Atualizar(LocalizacaoEntity entity)
        {
            var localizacaoExistente = _context.Localizacoes.Find(entity.IdLocalizacao);
            if (localizacaoExistente is null) return null;

            localizacaoExistente.NomeLocalizacao = entity.NomeLocalizacao;
            localizacaoExistente.Latitude = entity.Latitude;
            localizacaoExistente.Longitude = entity.Longitude;

            _context.Localizacoes.Update(localizacaoExistente);
            _context.SaveChanges();

            return localizacaoExistente;
        }

        public LocalizacaoEntity? Deletar(int id)
        {
            var localizacaoExistente = _context.Localizacoes.Find(id);
            if (localizacaoExistente is not null)
            {
                _context.Localizacoes.Remove(localizacaoExistente);
                _context.SaveChanges();
                return localizacaoExistente;
            }
            return null;
        }
    }
}
