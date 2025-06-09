using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alagaqui.Migrations
{
    /// <inheritdoc />
    public partial class intitdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_alagaqui_localizacoes",
                columns: table => new
                {
                    id_localizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_localizacao = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alagaqui_localizacoes", x => x.id_localizacao);
                });

            migrationBuilder.CreateTable(
                name: "tb_alagaqui_ocorrencias",
                columns: table => new
                {
                    id_ocorrencia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_localizacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    titulo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: false),
                    data_hora_ocorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alagaqui_ocorrencias", x => x.id_ocorrencia);
                });

            migrationBuilder.CreateTable(
                name: "tb_alagaqui_tipos_alertas",
                columns: table => new
                {
                    id_tipo_alerta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    descricao_tipo_alerta = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alagaqui_tipos_alertas", x => x.id_tipo_alerta);
                });

            migrationBuilder.CreateTable(
                name: "tb_alagaqui_usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_usuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    email_usuario = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    senha_usuario = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    data_ultima_criacao_relato = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alagaqui_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_alagaqui_alertas",
                columns: table => new
                {
                    id_alerta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_ocorrencia_relacionada = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_tipo_alerta = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    mensagem_alerta = table.Column<string>(type: "NCLOB", maxLength: 4000, nullable: false),
                    data_hora_criacao_alerta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    resolvido_alerta = table.Column<string>(type: "NVARCHAR2(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alagaqui_alertas", x => x.id_alerta);
                    table.ForeignKey(
                        name: "FK_tb_alagaqui_alertas_tb_alagaqui_tipos_alertas_id_tipo_alerta",
                        column: x => x.id_tipo_alerta,
                        principalTable: "tb_alagaqui_tipos_alertas",
                        principalColumn: "id_tipo_alerta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_alagaqui_alertas_id_tipo_alerta",
                table: "tb_alagaqui_alertas",
                column: "id_tipo_alerta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_alagaqui_alertas");

            migrationBuilder.DropTable(
                name: "tb_alagaqui_localizacoes");

            migrationBuilder.DropTable(
                name: "tb_alagaqui_ocorrencias");

            migrationBuilder.DropTable(
                name: "tb_alagaqui_usuarios");

            migrationBuilder.DropTable(
                name: "tb_alagaqui_tipos_alertas");
        }
    }
}
