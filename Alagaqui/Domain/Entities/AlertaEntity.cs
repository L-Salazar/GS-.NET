using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alagaqui.Domain.Entities
{
    [Table("tb_alagaqui_alertas")]
    public class AlertaEntity
    {
        [Key]
        [Column("id_alerta")]
        public int IdAlerta { get; set; }

        [Required]
        [Column("id_ocorrencia_relacionada")]
        public int IdOcorrenciaRelacionada { get; set; }

        [Required]
        [Column("id_tipo_alerta")]
        public int IdTipoAlerta { get; set; }

        [Required]
        [Column("mensagem_alerta")]
        [MaxLength(4000)]
        public string MensagemAlerta { get; set; }

        [Required]
        [Column("data_hora_criacao_alerta")]
        public DateTime DataHoraCriacaoAlerta { get; set; }

        [Required]
        [Column("resolvido_alerta")]
        public char ResolvidoAlerta { get; set; }
    }
}
