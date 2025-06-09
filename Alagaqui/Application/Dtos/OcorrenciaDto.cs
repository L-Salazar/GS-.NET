using System;
using System.ComponentModel.DataAnnotations;

namespace Alagaqui.Application.Dtos
{
    public class OcorrenciaDto
    {
        public int IdOcorrencia { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O ID da localização é obrigatório")]
        public int IdLocalizacao { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [MaxLength(255, ErrorMessage = "O título deve ter no máximo 255 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(4000, ErrorMessage = "A descrição deve ter no máximo 4000 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data e hora da ocorrência é obrigatória")]
        public DateTime DataHoraOcorrencia { get; set; }
    }
}
