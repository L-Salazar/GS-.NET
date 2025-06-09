using System.ComponentModel.DataAnnotations;

namespace Alagaqui.Application.Dtos
{
    public class TipoAlertaDto
    {
        public int IdTipoAlerta { get; set; }

        [Required(ErrorMessage = "A descrição do tipo de alerta é obrigatória")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no máximo 50 caracteres")]
        public string DescricaoTipoAlerta { get; set; } = string.Empty;
    }
}
