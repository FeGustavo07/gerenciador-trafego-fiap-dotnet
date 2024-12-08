using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiap.gerenciador_trafego.Migrations
{
    /// <inheritdoc />
    public partial class Clima : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_gti_clima");
        }
    }
}
