using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class _20240226 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creado",
                table: "Domicilio",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modificado",
                table: "Domicilio",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Domicilio",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Rubro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<int>(type: "integer", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    TiempoPreparacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RubroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturado_Rubro_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HoraEstimada = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Retirolocal = table.Column<bool>(type: "boolean", nullable: false),
                    Descuento = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleManufacturado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArticuloId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManufacturadoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleManufacturado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleManufacturado_Manufacturado_ManufacturadoId",
                        column: x => x.ManufacturadoId,
                        principalTable: "Manufacturado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ManufacturadoId = table.Column<Guid>(type: "uuid", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Manufacturado_ManufacturadoId",
                        column: x => x.ManufacturadoId,
                        principalTable: "Manufacturado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Efectivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efectivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Efectivo_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MercadoPago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    CVU = table.Column<string>(type: "text", nullable: false),
                    Alias = table.Column<string>(type: "text", nullable: false),
                    CuilCuit = table.Column<string>(type: "text", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercadoPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MercadoPago_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    UnidadMedida = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    DetallePedidoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DetalleManufacturadoId = table.Column<Guid>(type: "uuid", nullable: false),
                    RubroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulo_DetalleManufacturado_DetalleManufacturadoId",
                        column: x => x.DetalleManufacturadoId,
                        principalTable: "DetalleManufacturado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articulo_DetallePedido_DetallePedidoId",
                        column: x => x.DetallePedidoId,
                        principalTable: "DetallePedido",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articulo_Rubro_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompraArticulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false),
                    ArticuloId = table.Column<Guid>(type: "uuid", nullable: false),
                    Creado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraArticulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraArticulo_Articulo_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_UsuarioId",
                table: "Domicilio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_DetalleManufacturadoId",
                table: "Articulo",
                column: "DetalleManufacturadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_DetallePedidoId",
                table: "Articulo",
                column: "DetallePedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_RubroId",
                table: "Articulo",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraArticulo_ArticuloId",
                table: "CompraArticulo",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleManufacturado_ManufacturadoId",
                table: "DetalleManufacturado",
                column: "ManufacturadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ManufacturadoId",
                table: "DetallePedido",
                column: "ManufacturadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoId",
                table: "DetallePedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Efectivo_PedidoId",
                table: "Efectivo",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturado_RubroId",
                table: "Manufacturado",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_MercadoPago_PedidoId",
                table: "MercadoPago",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domicilio_Usuario_UsuarioId",
                table: "Domicilio",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domicilio_Usuario_UsuarioId",
                table: "Domicilio");

            migrationBuilder.DropTable(
                name: "CompraArticulo");

            migrationBuilder.DropTable(
                name: "Efectivo");

            migrationBuilder.DropTable(
                name: "MercadoPago");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "DetalleManufacturado");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Manufacturado");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Rubro");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Domicilio_UsuarioId",
                table: "Domicilio");

            migrationBuilder.DropColumn(
                name: "Creado",
                table: "Domicilio");

            migrationBuilder.DropColumn(
                name: "Modificado",
                table: "Domicilio");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Domicilio");
        }
    }
}
