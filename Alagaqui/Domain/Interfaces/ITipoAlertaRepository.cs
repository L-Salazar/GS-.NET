using Alagaqui.Domain.Entities;

namespace Alagaqui.Domain.Interfaces
{
    public interface ITipoAlertaRepository
    {
        IEnumerable<TipoAlertaEntity> ObterTodos();
        TipoAlertaEntity? ObterPorId(int id);
        TipoAlertaEntity? Salvar(TipoAlertaEntity entity);
        TipoAlertaEntity? Atualizar(TipoAlertaEntity entity);
        TipoAlertaEntity? Deletar(int id);
        IEnumerable<TipoAlertaEntity> ObterTodosComAlertas();
    }
}
