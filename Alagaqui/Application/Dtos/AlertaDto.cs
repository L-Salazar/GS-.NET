using System;
using System.ComponentModel.DataAnnotations;

namespace Alagaqui.Application.Dtos
{
    public class AlertaDto
    {
        public int IdAlerta { get; set; }

        [Required(ErrorMessage = "O ID da ocorrência relacionada é obrigatório")]
        public int IdOcorrenciaRelacionada { get; set; }

        [Required(ErrorMessage = "O ID do tipo de alerta é obrigatório")]
        public int IdTipoAlerta { get; set; }

        [Required(ErrorMessage = "A mensagem do alerta é obrigatória")]
        [MaxLength(4000, ErrorMessage = "A mensagem deve ter no máximo 4000 caracteres")]
        public string MensagemAlerta { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data e hora de criação do alerta é obrigatória")]
        public DateTime DataHoraCriacaoAlerta { get; set; }

        [Required(ErrorMessage = "O status de resolução do alerta é obrigatório")]
        public char ResolvidoAlerta { get; set; }
    }
}
