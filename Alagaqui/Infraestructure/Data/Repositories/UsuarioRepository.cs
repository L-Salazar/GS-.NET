using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;
using Alagaqui.Infrastructure.Data.AppData;

namespace Alagaqui.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioEntity> ObterTodos()
        {
            return _context.Usuarios.ToList();
        }

        public UsuarioEntity? ObterPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public UsuarioEntity? Salvar(UsuarioEntity entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public UsuarioEntity? Atualizar(UsuarioEntity entity)
        {
            var usuarioExistente = _context.Usuarios.Find(entity.IdUsuario);
            if (usuarioExistente is null) return null;

            usuarioExistente.NomeUsuario = entity.NomeUsuario;
            usuarioExistente.EmailUsuario = entity.EmailUsuario;
            usuarioExistente.SenhaUsuario = entity.SenhaUsuario;
            usuarioExistente.DataUltimaCriacaoRelato = entity.DataUltimaCriacaoRelato;

            _context.Usuarios.Update(usuarioExistente);
            _context.SaveChanges();

            return usuarioExistente;
        }

        public UsuarioEntity? Deletar(int id)
        {
            var usuarioExistente = _context.Usuarios.Find(id);
            if (usuarioExistente is not null)
            {
                _context.Usuarios.Remove(usuarioExistente);
                _context.SaveChanges();
                return usuarioExistente;
            }
            return null;
        }
    }
}
