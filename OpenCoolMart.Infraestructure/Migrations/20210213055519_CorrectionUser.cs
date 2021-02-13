using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCoolMart.Infraestructure.Migrations
{
    public partial class CorrectionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
