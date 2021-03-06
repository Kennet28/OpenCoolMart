﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenCoolMart.Infraestructure.Data;

namespace OpenCoolMart.Infraestructure.Migrations
{
    [DbContext(typeof(OpenCoolMartContext))]
    [Migration("20210213055519_CorrectionUser")]
    partial class CorrectionUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Domicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("float");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("ProveedorId")
                        .IsUnique();

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.CompraProducto", b =>
                {
                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadProducto")
                        .HasColumnType("int");

                    b.Property<double>("TotalPorProducto")
                        .HasColumnType("float");

                    b.HasKey("CompraId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("CompraProductos");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.DetallesVenta", b =>
                {
                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("CantiProd")
                        .HasColumnType("int");

                    b.Property<double>("VentaProductos")
                        .HasColumnType("float");

                    b.HasKey("VentaId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallesVentas");

                    b
                        .HasAnnotation("Relational:MaxIdentifierLength", 128)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CodigoEmpleado")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("PerfilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PerfilId");

                    b.ToTable("Perfils");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Permiso", b =>
                {
                    b.Property<int>("PermisoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Modulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermisoId");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodigoProducto")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Descuento")
                        .HasColumnType("float");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioCompra")
                        .HasColumnType("float");

                    b.Property<double>("PrecioVenta")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("builderit");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b
                        .HasAnnotation("Relational:MaxIdentifierLength", 128)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Proveedors");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Respaldos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("Ruta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Respaldo");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CajaId")
                        .HasColumnType("int");

                    b.Property<double>("Cambio")
                        .HasColumnType("float");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<double>("Efectivo")
                        .HasColumnType("float");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime2");

                    b.Property<int>("Folio")
                        .HasColumnType("int");

                    b.Property<string>("FormaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Iva")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<double>("VentaTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Ventas");

                    b
                        .HasAnnotation("Relational:MaxIdentifierLength", 128)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Compra", b =>
                {
                    b.HasOne("OpenCoolMart.Domain.Entities.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenCoolMart.Domain.Entities.Proveedor", "Proveedor")
                        .WithOne("Compra")
                        .HasForeignKey("OpenCoolMart.Domain.Entities.Compra", "ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.CompraProducto", b =>
                {
                    b.HasOne("OpenCoolMart.Domain.Entities.Compra", null)
                        .WithMany("CompraProductos")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenCoolMart.Domain.Entities.Producto", "Producto")
                        .WithMany("CompraProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.DetallesVenta", b =>
                {
                    b.HasOne("OpenCoolMart.Domain.Entities.Producto", "Producto")
                        .WithMany("DetallesVentas")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenCoolMart.Domain.Entities.Venta", null)
                        .WithMany("DetallesVentas")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("OpenCoolMart.Domain.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Venta", b =>
                {
                    b.HasOne("OpenCoolMart.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_Ventas_Clientes_ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenCoolMart.Domain.Entities.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .HasConstraintName("FK_Ventas_Empleados_EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Compra", b =>
                {
                    b.Navigation("CompraProductos");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Producto", b =>
                {
                    b.Navigation("CompraProductos");

                    b.Navigation("DetallesVentas");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("Compra");
                });

            modelBuilder.Entity("OpenCoolMart.Domain.Entities.Venta", b =>
                {
                    b.Navigation("DetallesVentas");
                });
#pragma warning restore 612, 618
        }
    }
}
