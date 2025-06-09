using Alagaqui.Application.Dtos;
using Alagaqui.Domain.Entities;

namespace Alagaqui.Application.Interfaces
{
    public interface ITipoAlertaApplicationService
    {
        IEnumerable<TipoAlertaEntity> ObterTodosTiposAlerta();
        TipoAlertaEntity? ObterTipoAlertaPorId(int id);
        TipoAlertaEntity? SalvarDadosTipoAlerta(TipoAlertaDto dto);
        TipoAlertaEntity? EditarDadosTipoAlerta(int id, TipoAlertaDto dto);
        TipoAlertaEntity? DeletarDadosTipoAlerta(int id);
        IEnumerable<TipoAlertaEntity> ObterTiposComAlertas();
    }
}
