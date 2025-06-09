using Alagaqui.Domain.Entities;

namespace Alagaqui.Domain.Interfaces
{
    public interface IOcorrenciaRepository
    {
        IEnumerable<OcorrenciaEntity> ObterTodos();
        OcorrenciaEntity? ObterPorId(int id);
        OcorrenciaEntity? Salvar(OcorrenciaEntity entity);
        OcorrenciaEntity? Atualizar(OcorrenciaEntity entity);
        OcorrenciaEntity? Deletar(int id);
    }
}
