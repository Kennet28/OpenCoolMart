using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCoolMart.Infraestructure.Migrations
{
    public partial class Correccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas");
        }
    }
}
