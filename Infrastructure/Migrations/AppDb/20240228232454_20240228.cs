using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class _20240228 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_DetalleManufacturado_DetalleManufacturadoId",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_DetalleManufacturadoId",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "DetalleManufacturadoId",
                table: "Articulo");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleManufacturado_ArticuloId",
                table: "DetalleManufacturado",
                column: "ArticuloId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleManufacturado_Articulo_ArticuloId",
                table: "DetalleManufacturado",
                column: "ArticuloId",
                principalTable: "Articulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleManufacturado_Articulo_ArticuloId",
                table: "DetalleManufacturado");

            migrationBuilder.DropIndex(
                name: "IX_DetalleManufacturado_ArticuloId",
                table: "DetalleManufacturado");

            migrationBuilder.AddColumn<Guid>(
                name: "DetalleManufacturadoId",
                table: "Articulo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_DetalleManufacturadoId",
                table: "Articulo",
                column: "DetalleManufacturadoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_DetalleManufacturado_DetalleManufacturadoId",
                table: "Articulo",
                column: "DetalleManufacturadoId",
                principalTable: "DetalleManufacturado",
                principalColumn: "Id");
        }
    }
}
