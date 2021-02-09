using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCoolMart.Infraestructure.Migrations
{
    public partial class deleteTBCajas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cajas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadDiaria = table.Column<double>(type: "float", nullable: false),
                    CantidadTotal = table.Column<double>(type: "float", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoRetirado = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cajas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CajaId",
                table: "Ventas",
                column: "CajaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cajas_CajaId",
                table: "Ventas",
                column: "CajaId",
                principalTable: "Cajas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
