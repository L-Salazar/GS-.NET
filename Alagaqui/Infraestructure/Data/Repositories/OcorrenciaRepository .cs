using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;
using Alagaqui.Infrastructure.Data.AppData;

namespace Alagaqui.Infrastructure.Data.Repositories
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly ApplicationContext _context;

        public OcorrenciaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<OcorrenciaEntity> ObterTodos()
        {
            return _context.Ocorrencias.ToList();
        }

        public OcorrenciaEntity? ObterPorId(int id)
        {
            return _context.Ocorrencias.Find(id);
        }

        public OcorrenciaEntity? Salvar(OcorrenciaEntity entity)
        {
            _context.Ocorrencias.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public OcorrenciaEntity? Atualizar(OcorrenciaEntity entity)
        {
            var ocorrenciaExistente = _context.Ocorrencias.Find(entity.IdOcorrencia);
            if (ocorrenciaExistente is null) return null;

            ocorrenciaExistente.IdUsuario = entity.IdUsuario;
            ocorrenciaExistente.IdLocalizacao = entity.IdLocalizacao;
            ocorrenciaExistente.Titulo = entity.Titulo;
            ocorrenciaExistente.Descricao = entity.Descricao;
            ocorrenciaExistente.DataHoraOcorrencia = entity.DataHoraOcorrencia;

            _context.Ocorrencias.Update(ocorrenciaExistente);
            _context.SaveChanges();

            return ocorrenciaExistente;
        }

        public OcorrenciaEntity? Deletar(int id)
        {
            var ocorrenciaExistente = _context.Ocorrencias.Find(id);
            if (ocorrenciaExistente is not null)
            {
                _context.Ocorrencias.Remove(ocorrenciaExistente);
                _context.SaveChanges();
                return ocorrenciaExistente;
            }
            return null;
        }
    }
}
