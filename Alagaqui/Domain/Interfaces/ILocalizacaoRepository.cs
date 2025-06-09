using Alagaqui.Domain.Entities;

namespace Alagaqui.Domain.Interfaces
{
    public interface ILocalizacaoRepository
    {
        IEnumerable<LocalizacaoEntity> ObterTodos();
        LocalizacaoEntity? ObterPorId(int id);
        LocalizacaoEntity? Salvar(LocalizacaoEntity entity);
        LocalizacaoEntity? Atualizar(LocalizacaoEntity entity);
        LocalizacaoEntity? Deletar(int id);
    }
}
