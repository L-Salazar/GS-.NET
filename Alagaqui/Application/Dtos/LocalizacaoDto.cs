using System.ComponentModel.DataAnnotations;

namespace Alagaqui.Application.Dtos
{
    public class LocalizacaoDto
    {
        public int IdLocalizacao { get; set; }

        [Required(ErrorMessage = "O nome da localização é obrigatório")]
        [MaxLength(150, ErrorMessage = "O nome da localização deve ter no máximo 150 caracteres")]
        public string NomeLocalizacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A latitude é obrigatória")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória")]
        public double Longitude { get; set; }
    }
}
