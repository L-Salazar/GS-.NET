using System.ComponentModel.DataAnnotations;

namespace Alagaqui.Application.Dtos
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do usuário deve ter no máximo 100 caracteres")]
        public string NomeUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        [MaxLength(150, ErrorMessage = "O email deve ter no máximo 150 caracteres")]
        public string EmailUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres")]
        public string SenhaUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data da última criação de relato é obrigatória")]
        public DateTime DataUltimaCriacaoRelato { get; set; }
    }
}
