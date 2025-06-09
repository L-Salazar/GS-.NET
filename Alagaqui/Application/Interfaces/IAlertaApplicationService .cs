using Alagaqui.Application.Dtos;
using Alagaqui.Domain.Entities;

namespace Alagaqui.Application.Interfaces
{
    public interface IAlertaApplicationService
    {
        IEnumerable<AlertaEntity> ObterTodosAlertas();
        AlertaEntity? ObterAlertaPorId(int id);
        AlertaEntity? SalvarDadosAlerta(AlertaDto dto);
        AlertaEntity? EditarDadosAlerta(int id, AlertaDto dto);
        AlertaEntity? DeletarDadosAlerta(int id);
    }
}
