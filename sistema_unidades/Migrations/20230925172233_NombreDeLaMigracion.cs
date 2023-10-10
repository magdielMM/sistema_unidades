using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistema_unidades.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "n_serie",
                table: "unidad",
                type: "char(4)",
                unicode: false,
                fixedLength: true,
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "n_serie",
                table: "unidad",
                type: "int",
                unicode: false,
                fixedLength: true,
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(4)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 4);
        }
    }
}
