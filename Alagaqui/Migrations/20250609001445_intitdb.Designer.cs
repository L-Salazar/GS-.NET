﻿// <auto-generated />
using System;
using Alagaqui.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Alagaqui.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250609001445_intitdb")]
    partial class intitdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Alagaqui.Domain.Entities.AlertaEntity", b =>
                {
                    b.Property<int>("IdAlerta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_alerta");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlerta"));

                    b.Property<DateTime>("DataHoraCriacaoAlerta")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_hora_criacao_alerta");

                    b.Property<int>("IdOcorrenciaRelacionada")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_ocorrencia_relacionada");

                    b.Property<int>("IdTipoAlerta")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_tipo_alerta");

                    b.Property<string>("MensagemAlerta")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("NCLOB")
                        .HasColumnName("mensagem_alerta");

                    b.Property<string>("ResolvidoAlerta")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(1)")
                        .HasColumnName("resolvido_alerta");

                    b.HasKey("IdAlerta");

                    b.HasIndex("IdTipoAlerta");

                    b.ToTable("tb_alagaqui_alertas");
                });

            modelBuilder.Entity("Alagaqui.Domain.Entities.LocalizacaoEntity", b =>
                {
                    b.Property<int>("IdLocalizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_localizacao");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLocalizacao"));

                    b.Property<double>("Latitude")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("latitude");

                    b.Property<double>("Longitude")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("longitude");

                    b.Property<string>("NomeLocalizacao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)")
                        .HasColumnName("nome_localizacao");

                    b.HasKey("IdLocalizacao");

                    b.ToTable("tb_alagaqui_localizacoes");
                });

            modelBuilder.Entity("Alagaqui.Domain.Entities.OcorrenciaEntity", b =>
                {
                    b.Property<int>("IdOcorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_ocorrencia");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOcorrencia"));

                    b.Property<DateTime>("DataHoraOcorrencia")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_hora_ocorrencia");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("NCLOB")
                        .HasColumnName("descricao");

                    b.Property<int>("IdLocalizacao")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_localizacao");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_usuario");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("titulo");

                    b.HasKey("IdOcorrencia");

                    b.ToTable("tb_alagaqui_ocorrencias");
                });

            modelBuilder.Entity("Alagaqui.Domain.Entities.TipoAlertaEntity", b =>
                {
                    b.Property<int>("IdTipoAlerta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_tipo_alerta");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoAlerta"));

                    b.Property<string>("DescricaoTipoAlerta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("descricao_tipo_alerta");

                    b.HasKey("IdTipoAlerta");

                    b.ToTable("tb_alagaqui_tipos_alertas");
                });

            modelBuilder.Entity("Alagaqui.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_usuario");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<DateTime>("DataUltimaCriacaoRelato")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_ultima_criacao_relato");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)")
                        .HasColumnName("email_usuario");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("nome_usuario");

                    b.Property<string>("SenhaUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("senha_usuario");

                    b.HasKey("IdUsuario");

                    b.ToTable("tb_alagaqui_usuarios");
                });

            modelBuilder.Entity("Alagaqui.Domain.Entities.AlertaEntity", b =>
                {
                    b.HasOne("Alagaqui.Domain.Entities.TipoAlertaEntity", null)
                        .WithMany("Alertas")
                        .HasForeignKey("IdTipoAlerta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Alagaqui.Domain.Entities.TipoAlertaEntity", b =>
                {
                    b.Navigation("Alertas");
                });
#pragma warning restore 612, 618
        }
    }
}
