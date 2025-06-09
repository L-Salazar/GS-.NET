using Alagaqui.Application.Dtos;
using Alagaqui.Application.Interfaces;
using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;

namespace Alagaqui.Application.Services
{
    public class LocalizacaoApplicationService : ILocalizacaoApplicationService
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;

        public LocalizacaoApplicationService(ILocalizacaoRepository localizacaoRepository)
        {
            _localizacaoRepository = localizacaoRepository;
        }

        public IEnumerable<LocalizacaoEntity> ObterTodasLocalizacoes()
        {
            return _localizacaoRepository.ObterTodos();
        }

        public LocalizacaoEntity? ObterLocalizacaoPorId(int id)
        {
            return _localizacaoRepository.ObterPorId(id);
        }

        public LocalizacaoEntity? SalvarDadosLocalizacao(LocalizacaoDto dto)
        {
            var novaLocalizacao = new LocalizacaoEntity
            {
                NomeLocalizacao = dto.NomeLocalizacao,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };

            return _localizacaoRepository.Salvar(novaLocalizacao);
        }

        public LocalizacaoEntity? EditarDadosLocalizacao(int id, LocalizacaoDto dto)
        {
            var localizacaoAtualizada = new LocalizacaoEntity
            {
                IdLocalizacao = id,
                NomeLocalizacao = dto.NomeLocalizacao,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };

            return _localizacaoRepository.Atualizar(localizacaoAtualizada);
        }

        public LocalizacaoEntity? DeletarDadosLocalizacao(int id)
        {
            return _localizacaoRepository.Deletar(id);
        }
    }
}
