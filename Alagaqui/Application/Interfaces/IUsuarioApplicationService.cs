using Alagaqui.Application.Dtos;
using Alagaqui.Domain.Entities;

namespace Alagaqui.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        IEnumerable<UsuarioEntity> ObterTodosUsuarios();
        UsuarioEntity? ObterUsuarioPorId(int id);
        UsuarioEntity? SalvarDadosUsuario(UsuarioDto dto);
        UsuarioEntity? EditarDadosUsuario(int id, UsuarioDto dto);
        UsuarioEntity? DeletarDadosUsuario(int id);
    }
}
