using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCoolMart.Infraestructure.Migrations
{
    public partial class AddMigration_Folio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolioId",
                table: "Ventas");

            migrationBuilder.AddColumn<int>(
                name: "Folio",
                table: "Ventas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Folio",
                table: "Ventas");

            migrationBuilder.AddColumn<int>(
                name: "FolioId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
