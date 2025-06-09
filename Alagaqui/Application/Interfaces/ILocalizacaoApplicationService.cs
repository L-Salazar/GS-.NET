using Alagaqui.Application.Dtos;
using Alagaqui.Domain.Entities;

namespace Alagaqui.Application.Interfaces
{
    public interface ILocalizacaoApplicationService
    {
        IEnumerable<LocalizacaoEntity> ObterTodasLocalizacoes();
        LocalizacaoEntity? ObterLocalizacaoPorId(int id);
        LocalizacaoEntity? SalvarDadosLocalizacao(LocalizacaoDto dto);
        LocalizacaoEntity? EditarDadosLocalizacao(int id, LocalizacaoDto dto);
        LocalizacaoEntity? DeletarDadosLocalizacao(int id);
    }
}
