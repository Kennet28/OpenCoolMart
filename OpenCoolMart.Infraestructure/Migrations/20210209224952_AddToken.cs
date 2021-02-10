using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCoolMart.Infraestructure.Migrations
{
    public partial class AddToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermisoId",
                table: "Perfils");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfils_PerfilId",
                table: "Usuarios",
                column: "PerfilId",
                principalTable: "Perfils",
                principalColumn: "PerfilId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfils_PerfilId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "PermisoId",
                table: "Perfils",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
