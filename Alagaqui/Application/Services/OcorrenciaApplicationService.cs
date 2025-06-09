using Alagaqui.Application.Dtos;
using Alagaqui.Application.Interfaces;
using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;

namespace Alagaqui.Application.Services
{
    public class OcorrenciaApplicationService : IOcorrenciaApplicationService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaApplicationService(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public IEnumerable<OcorrenciaEntity> ObterTodasOcorrencias()
        {
            return _ocorrenciaRepository.ObterTodos();
        }

        public OcorrenciaEntity? ObterOcorrenciaPorId(int id)
        {
            return _ocorrenciaRepository.ObterPorId(id);
        }

        public OcorrenciaEntity? SalvarDadosOcorrencia(OcorrenciaDto dto)
        {
            var novaOcorrencia = new OcorrenciaEntity
            {
                IdUsuario = dto.IdUsuario,
                IdLocalizacao = dto.IdLocalizacao,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataHoraOcorrencia = dto.DataHoraOcorrencia
            };

            return _ocorrenciaRepository.Salvar(novaOcorrencia);
        }

        public OcorrenciaEntity? EditarDadosOcorrencia(int id, OcorrenciaDto dto)
        {
            var ocorrenciaAtualizada = new OcorrenciaEntity
            {
                IdOcorrencia = id,
                IdUsuario = dto.IdUsuario,
                IdLocalizacao = dto.IdLocalizacao,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataHoraOcorrencia = dto.DataHoraOcorrencia
            };

            return _ocorrenciaRepository.Atualizar(ocorrenciaAtualizada);
        }

        public OcorrenciaEntity? DeletarDadosOcorrencia(int id)
        {
            return _ocorrenciaRepository.Deletar(id);
        }
    }
}
