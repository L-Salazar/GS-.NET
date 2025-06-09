using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alagaqui.Domain.Entities
{
    [Table("tb_alagaqui_tipos_alertas")]
    public class TipoAlertaEntity
    {
        [Key]
        [Column("id_tipo_alerta")]
        public int IdTipoAlerta { get; set; }

        [Required]
        [Column("descricao_tipo_alerta")]
        [MaxLength(50)]
        public string DescricaoTipoAlerta { get; set; }

        // Relacionamento 1:N
        public virtual ICollection<AlertaEntity> Alertas { get; set; } = new List<AlertaEntity>();
    }
}
