using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCoolMart.Infraestructure.Migrations
{
    public partial class CorrectionError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Ventas_VentaId",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "Folio",
                table: "Ventas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VentaId",
                table: "Facturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Facturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Ventas_VentaId",
                table: "Facturas",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Ventas_VentaId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Folio",
                table: "Ventas");

            migrationBuilder.AlterColumn<int>(
                name: "VentaId",
                table: "Facturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Facturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Ventas_VentaId",
                table: "Facturas",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
