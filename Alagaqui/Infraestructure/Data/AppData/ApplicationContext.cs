using Alagaqui.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alagaqui.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        public DbSet<LocalizacaoEntity> Localizacoes { get; set; }

        public DbSet<AlertaEntity> Alertas { get; set; }

        public DbSet<TipoAlertaEntity> TiposAlerta { get; set; }

        public DbSet<OcorrenciaEntity> Ocorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoAlertaEntity>()
                .HasMany(t => t.Alertas)
                .WithOne()
                .HasForeignKey(a => a.IdTipoAlerta);
        }
    }
}
