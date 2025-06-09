using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alagaqui.Domain.Entities
{
    [Table("tb_alagaqui_usuarios")]
    public class UsuarioEntity
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Required]
        [Column("nome_usuario")]
        [MaxLength(100)]
        public string NomeUsuario { get; set; }

        [Required]
        [Column("email_usuario")]
        [MaxLength(150)]
        public string EmailUsuario { get; set; }

        [Required]
        [Column("senha_usuario")]
        [MaxLength(255)]
        public string SenhaUsuario { get; set; }

        [Required]
        [Column("data_ultima_criacao_relato")]
        public DateTime DataUltimaCriacaoRelato { get; set; }
    }
}
