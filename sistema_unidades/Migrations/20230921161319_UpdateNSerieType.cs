using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistema_unidades.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNSerieType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placa = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    folio = table.Column<long>(type: "bigint", nullable: false),
                    n_serie = table.Column<string>(type: "int", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    id_tipo = table.Column<int>(type: "int", nullable: false),
                    id_periodo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro", x => x.id);
                    table.ForeignKey(
                        name: "FK_registro_cliente",
                        column: x => x.id_cliente,
                        principalTable: "cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_unidad_periodo",
                        column: x => x.id_periodo,
                        principalTable: "periodo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_unidad_tipo",
                        column: x => x.id_tipo,
                        principalTable: "tipo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_unidad_id_cliente",
                table: "unidad",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_unidad_id_periodo",
                table: "unidad",
                column: "id_periodo");

            migrationBuilder.CreateIndex(
                name: "IX_unidad_id_tipo",
                table: "unidad",
                column: "id_tipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unidad");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "periodo");

            migrationBuilder.DropTable(
                name: "tipo");
        }
    }
}
