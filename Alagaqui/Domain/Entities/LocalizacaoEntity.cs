using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alagaqui.Domain.Entities
{
    [Table("tb_alagaqui_localizacoes")]
    public class LocalizacaoEntity
    {
        [Key]
        [Column("id_localizacao")]
        public int IdLocalizacao { get; set; }

        [Required]
        [Column("nome_localizacao")]
        [MaxLength(150)]
        public string NomeLocalizacao { get; set; }

        [Required]
        [Column("latitude")]
        public double Latitude { get; set; }

        [Required]
        [Column("longitude")]
        public double Longitude { get; set; }
    }
}
