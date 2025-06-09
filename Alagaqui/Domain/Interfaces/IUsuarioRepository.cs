using Alagaqui.Domain.Entities;

namespace Alagaqui.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioEntity> ObterTodos();
        UsuarioEntity? ObterPorId(int id);
        UsuarioEntity? Salvar(UsuarioEntity entity);
        UsuarioEntity? Atualizar(UsuarioEntity entity);
        UsuarioEntity? Deletar(int id);
    }
}
