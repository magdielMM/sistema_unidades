using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistema_unidades.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "n_serie",
            table: "unidad",
            type: "varchar(50)", // Nuevo tipo de dato
            nullable: false,       // Ajusta según tu caso
            oldClrType: typeof(int), // Tipo de dato anterior
            oldType: "int");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
