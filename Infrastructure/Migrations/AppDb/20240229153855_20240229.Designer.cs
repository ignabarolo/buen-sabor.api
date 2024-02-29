﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations.AppDb
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240229153855_20240229")]
    partial class _20240229
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("buen_sabor.api.Entities.Articulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DetallePedidoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("RubroId")
                        .HasColumnType("uuid");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DetallePedidoId");

                    b.HasIndex("RubroId");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.CompraArticulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArticuloId")
                        .HasColumnType("uuid");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Precio")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.ToTable("CompraArticulo");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.DetalleManufacturado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArticuloId")
                        .HasColumnType("uuid");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ManufacturadoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId")
                        .IsUnique();

                    b.HasIndex("ManufacturadoId");

                    b.ToTable("DetalleManufacturado");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.DetallePedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ManufacturadoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturadoId")
                        .IsUnique();

                    b.HasIndex("PedidoId");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Domicilio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Nro")
                        .HasColumnType("integer");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Domicilio");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Efectivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Efectivo");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Manufacturado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("RubroId")
                        .HasColumnType("uuid");

                    b.Property<TimeOnly>("TiempoPreparacion")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("RubroId");

                    b.ToTable("Manufacturado");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.MercadoPago", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CVU")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CuilCuit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("MercadoPago");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Descuento")
                        .HasColumnType("integer");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HoraEstimada")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Retirolocal")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Rubro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rubro");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rol")
                        .HasColumnType("integer");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Articulo", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.DetallePedido", "DetallePedido")
                        .WithMany("Articulos")
                        .HasForeignKey("DetallePedidoId")
                        .IsRequired();

                    b.HasOne("buen_sabor.api.Entities.Rubro", "Rubro")
                        .WithMany("Articulos")
                        .HasForeignKey("RubroId")
                        .IsRequired();

                    b.Navigation("DetallePedido");

                    b.Navigation("Rubro");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.CompraArticulo", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Articulo", "Articulo")
                        .WithMany("CompraArticulos")
                        .HasForeignKey("ArticuloId")
                        .IsRequired();

                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.DetalleManufacturado", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Articulo", "Articulo")
                        .WithOne("DetalleManufacturado")
                        .HasForeignKey("buen_sabor.api.Entities.DetalleManufacturado", "ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("buen_sabor.api.Entities.Manufacturado", "Manufacturado")
                        .WithMany("DetallesManufacturado")
                        .HasForeignKey("ManufacturadoId")
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Manufacturado");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.DetallePedido", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Manufacturado", "Manufacturado")
                        .WithOne("DetallePedido")
                        .HasForeignKey("buen_sabor.api.Entities.DetallePedido", "ManufacturadoId");

                    b.HasOne("buen_sabor.api.Entities.Pedido", "Pedido")
                        .WithMany("DetallesPedidos")
                        .HasForeignKey("PedidoId")
                        .IsRequired();

                    b.Navigation("Manufacturado");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Domicilio", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Usuario", "Usuario")
                        .WithMany("Domicilios")
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Efectivo", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Pedido", "Pedido")
                        .WithOne("Efectivo")
                        .HasForeignKey("buen_sabor.api.Entities.Efectivo", "PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Manufacturado", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Rubro", "Rubro")
                        .WithMany("Manufacturados")
                        .HasForeignKey("RubroId")
                        .IsRequired();

                    b.Navigation("Rubro");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.MercadoPago", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Pedido", "Pedido")
                        .WithOne("MercadoPago")
                        .HasForeignKey("buen_sabor.api.Entities.MercadoPago", "PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Pedido", b =>
                {
                    b.HasOne("buen_sabor.api.Entities.Usuario", "Usuario")
                        .WithMany("Pedido")
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Articulo", b =>
                {
                    b.Navigation("CompraArticulos");

                    b.Navigation("DetalleManufacturado")
                        .IsRequired();
                });

            modelBuilder.Entity("buen_sabor.api.Entities.DetallePedido", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Manufacturado", b =>
                {
                    b.Navigation("DetallePedido")
                        .IsRequired();

                    b.Navigation("DetallesManufacturado");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Pedido", b =>
                {
                    b.Navigation("DetallesPedidos");

                    b.Navigation("Efectivo")
                        .IsRequired();

                    b.Navigation("MercadoPago")
                        .IsRequired();
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Rubro", b =>
                {
                    b.Navigation("Articulos");

                    b.Navigation("Manufacturados");
                });

            modelBuilder.Entity("buen_sabor.api.Entities.Usuario", b =>
                {
                    b.Navigation("Domicilios");

                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
