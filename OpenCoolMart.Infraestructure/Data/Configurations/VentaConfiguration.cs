using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Infraestructure.Data.Configurations
{
    class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<int>("CajaId")
                .HasColumnType("int");

            builder.Property<double>("Cambio")
                .HasColumnType("float");

            builder.Property<DateTime>("CreateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("CreatedBy")
                .HasColumnType("int");

            builder.Property<double>("Efectivo")
                .HasColumnType("float");

            builder.Property<int>("EmpleadoId")
                .HasColumnType("int");

            builder.Property<DateTime>("FechaVenta")
                .HasColumnType("datetime2");

            builder.Property<string>("FormaPago")
                .HasColumnType("nvarchar(max)");

            builder.Property<double>("Iva")
                .HasColumnType("float");

            builder.Property<bool>("Status")
                .HasColumnType("bit");

            builder.Property<double>("SubTotal")
                .HasColumnType("float");

            builder.Property<DateTime?>("UpdateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("UpdatedBy")
                .HasColumnType("int");

            builder.Property<double>("VentaTotal")
                .HasColumnType("float");
            builder.Property<int>("Folio")
                        .HasColumnType("int");

            builder.HasKey("Id");

            builder.HasIndex("CajaId");

            builder.HasIndex("EmpleadoId");

            builder.ToTable("Ventas");

            builder.HasOne("OpenCoolMart.Domain.Entities.Empleado", "Empleado")
                .WithMany()
                .HasForeignKey("EmpleadoId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Ventas_Empleados_EmpleadoId")
                .IsRequired();
            builder.HasOne(d => d.Caja)
                .WithMany(p => p.Ventas)
                .HasForeignKey(d => d.CajaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Cajas_CajaId");

        }
    }
}
