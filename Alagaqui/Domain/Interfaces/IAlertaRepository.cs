using Alagaqui.Domain.Entities;

namespace Alagaqui.Domain.Interfaces
{
    public interface IAlertaRepository
    {
        IEnumerable<AlertaEntity> ObterTodos();
        AlertaEntity? ObterPorId(int id);
        AlertaEntity? Salvar(AlertaEntity entity);
        AlertaEntity? Atualizar(AlertaEntity entity);
        AlertaEntity? Deletar(int id);
    }
}
