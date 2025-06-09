using Alagaqui.Application.Dtos;
using Alagaqui.Application.Interfaces;
using Alagaqui.Domain.Entities;
using Alagaqui.Domain.Interfaces;

namespace Alagaqui.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplicationService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioEntity> ObterTodosUsuarios()
        {
            return _usuarioRepository.ObterTodos();
        }

        public UsuarioEntity? ObterUsuarioPorId(int id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public UsuarioEntity? SalvarDadosUsuario(UsuarioDto dto)
        {
            var novoUsuario = new UsuarioEntity
            {
                NomeUsuario = dto.NomeUsuario,
                EmailUsuario = dto.EmailUsuario,
                SenhaUsuario = dto.SenhaUsuario,
                DataUltimaCriacaoRelato = dto.DataUltimaCriacaoRelato
            };

            return _usuarioRepository.Salvar(novoUsuario);
        }

        public UsuarioEntity? EditarDadosUsuario(int id, UsuarioDto dto)
        {
            var usuarioAtualizado = new UsuarioEntity
            {
                IdUsuario = id,
                NomeUsuario = dto.NomeUsuario,
                EmailUsuario = dto.EmailUsuario,
                SenhaUsuario = dto.SenhaUsuario,
                DataUltimaCriacaoRelato = dto.DataUltimaCriacaoRelato
            };

            return _usuarioRepository.Atualizar(usuarioAtualizado);
        }

        public UsuarioEntity? DeletarDadosUsuario(int id)
        {
            return _usuarioRepository.Deletar(id);
        }
    }
}
