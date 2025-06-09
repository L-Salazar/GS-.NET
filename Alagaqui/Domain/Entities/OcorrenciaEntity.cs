using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alagaqui.Domain.Entities
{
    [Table("tb_alagaqui_ocorrencias")]
    public class OcorrenciaEntity
    {
        [Key]
        [Column("id_ocorrencia")]
        public int IdOcorrencia { get; set; }

        [Required]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Required]
        [Column("id_localizacao")]
        public int IdLocalizacao { get; set; }

        [Required]
        [Column("titulo")]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Required]
        [Column("descricao")]
        [MaxLength(4000)]
        public string Descricao { get; set; }

        [Required]
        [Column("data_hora_ocorrencia")]
        public DateTime DataHoraOcorrencia { get; set; }
    }
}
