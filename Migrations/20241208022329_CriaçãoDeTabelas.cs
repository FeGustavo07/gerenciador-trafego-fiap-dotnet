using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiap.gerenciador_trafego.Migrations
{
    /// <inheritdoc />
    public partial class CriaçãoDeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_gti_clima",
                columns: table => new
                {
                    id_clima = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsCondicao = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    NrTemperatura = table.Column<decimal>(type: "number(10,2)", nullable: false),
                    NrUmidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DtRegistro = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_gti_clima", x => x.id_clima);
                });

            migrationBuilder.CreateTable(
                name: "t_usuario",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_usuario", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "t_gti_semaforo",
                columns: table => new
                {
                    id_semaforo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_localizacao = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    ds_estado = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false, defaultValue: "vermelho"),
                    nr_duracao_estado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dt_ult_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    t_gti_clima_id_clima = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_gti_semaforo", x => x.id_semaforo);
                    table.ForeignKey(
                        name: "FK_t_gti_semaforo_t_gti_clima_t_gti_clima_id_clima",
                        column: x => x.t_gti_clima_id_clima,
                        principalTable: "t_gti_clima",
                        principalColumn: "id_clima");
                });

            migrationBuilder.CreateTable(
                name: "t_gti_reg_acidente",
                columns: table => new
                {
                    id_reg_acidente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_local_acidente = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    dt_acidente = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ds_gravidade = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    nr_fluxo_impactado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    t_gti_semaforo_id_semaforo = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_gti_reg_acidente", x => x.id_reg_acidente);
                    table.ForeignKey(
                        name: "FK_t_gti_reg_acidente_t_gti_semaforo_t_gti_semaforo_id_semaforo",
                        column: x => x.t_gti_semaforo_id_semaforo,
                        principalTable: "t_gti_semaforo",
                        principalColumn: "id_semaforo");
                });

            migrationBuilder.CreateTable(
                name: "t_gti_sensor_trafego",
                columns: table => new
                {
                    id_sensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    qt_fluxo_veiculos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nr_visibilidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dt_deteccao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    t_gti_semaforo_id_semaforo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_gti_sensor_trafego", x => x.id_sensor);
                    table.ForeignKey(
                        name: "FK_t_gti_sensor_trafego_t_gti_semaforo_t_gti_semaforo_id_semaforo",
                        column: x => x.t_gti_semaforo_id_semaforo,
                        principalTable: "t_gti_semaforo",
                        principalColumn: "id_semaforo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_gti_rota",
                columns: table => new
                {
                    id_rota = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_descricao_rota = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    ds_status = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false, defaultValue: "ABERTA"),
                    t_reg_acidente_id_reg_acidente = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_gti_rota", x => x.id_rota);
                    table.ForeignKey(
                        name: "FK_t_gti_rota_t_gti_reg_acidente_t_reg_acidente_id_reg_acidente",
                        column: x => x.t_reg_acidente_id_reg_acidente,
                        principalTable: "t_gti_reg_acidente",
                        principalColumn: "id_reg_acidente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_gti_reg_acidente_t_gti_semaforo_id_semaforo",
                table: "t_gti_reg_acidente",
                column: "t_gti_semaforo_id_semaforo");

            migrationBuilder.CreateIndex(
                name: "IX_t_gti_rota_t_reg_acidente_id_reg_acidente",
                table: "t_gti_rota",
                column: "t_reg_acidente_id_reg_acidente");

            migrationBuilder.CreateIndex(
                name: "IX_t_gti_semaforo_t_gti_clima_id_clima",
                table: "t_gti_semaforo",
                column: "t_gti_clima_id_clima");

            migrationBuilder.CreateIndex(
                name: "IX_t_gti_sensor_trafego_t_gti_semaforo_id_semaforo",
                table: "t_gti_sensor_trafego",
                column: "t_gti_semaforo_id_semaforo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_gti_rota");

            migrationBuilder.DropTable(
                name: "t_gti_sensor_trafego");

            migrationBuilder.DropTable(
                name: "t_usuario");

            migrationBuilder.DropTable(
                name: "t_gti_reg_acidente");

            migrationBuilder.DropTable(
                name: "t_gti_semaforo");

            migrationBuilder.DropTable(
                name: "t_gti_clima");
        }
    }
}
