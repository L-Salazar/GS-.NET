using Alagaqui.Application.Dtos;
using Alagaqui.Domain.Entities;

namespace Alagaqui.Application.Interfaces
{
    public interface IOcorrenciaApplicationService
    {
        IEnumerable<OcorrenciaEntity> ObterTodasOcorrencias();
        OcorrenciaEntity? ObterOcorrenciaPorId(int id);
        OcorrenciaEntity? SalvarDadosOcorrencia(OcorrenciaDto dto);
        OcorrenciaEntity? EditarDadosOcorrencia(int id, OcorrenciaDto dto);
        OcorrenciaEntity? DeletarDadosOcorrencia(int id);
    }
}
