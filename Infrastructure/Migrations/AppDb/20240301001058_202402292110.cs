using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class _202402292110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Usuario",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Rubro",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraEstimada",
                table: "Pedido",
                type: "interval",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Pedido",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "MercadoPago",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Manufacturado",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Efectivo",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Domicilio",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "DetallePedido",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "DetalleManufacturado",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "CompraArticulo",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Articulo",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Rubro");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "MercadoPago");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Manufacturado");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Efectivo");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Domicilio");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "DetalleManufacturado");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "CompraArticulo");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Articulo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraEstimada",
                table: "Pedido",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");
        }
    }
}
