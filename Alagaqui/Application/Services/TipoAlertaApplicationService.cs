using Alagaqui.Application.Dtos;
using Alagaqui.Application.Interfaces;
using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;

namespace Alagaqui.Application.Services
{
    public class TipoAlertaApplicationService : ITipoAlertaApplicationService
    {
        private readonly ITipoAlertaRepository _tipoAlertaRepository;

        public TipoAlertaApplicationService(ITipoAlertaRepository tipoAlertaRepository)
        {
            _tipoAlertaRepository = tipoAlertaRepository;
        }

        public IEnumerable<TipoAlertaEntity> ObterTodosTiposAlerta()
        {
            return _tipoAlertaRepository.ObterTodos();
        }

        public TipoAlertaEntity? ObterTipoAlertaPorId(int id)
        {
            return _tipoAlertaRepository.ObterPorId(id);
        }

        public TipoAlertaEntity? SalvarDadosTipoAlerta(TipoAlertaDto dto)
        {
            var novoTipo = new TipoAlertaEntity
            {
                DescricaoTipoAlerta = dto.DescricaoTipoAlerta
            };

            return _tipoAlertaRepository.Salvar(novoTipo);
        }

        public TipoAlertaEntity? EditarDadosTipoAlerta(int id, TipoAlertaDto dto)
        {
            var tipoAtualizado = new TipoAlertaEntity
            {
                IdTipoAlerta = id,
                DescricaoTipoAlerta = dto.DescricaoTipoAlerta
            };

            return _tipoAlertaRepository.Atualizar(tipoAtualizado);
        }

        public TipoAlertaEntity? DeletarDadosTipoAlerta(int id)
        {
            return _tipoAlertaRepository.Deletar(id);
        }

        public IEnumerable<TipoAlertaEntity> ObterTiposComAlertas()
        {
            return _tipoAlertaRepository.ObterTodosComAlertas();
        }
    }
}
