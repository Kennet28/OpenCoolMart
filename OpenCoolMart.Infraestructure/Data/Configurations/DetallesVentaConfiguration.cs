using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Infraestructure.Data.Configurations
{
    class DetallesVentaConfiguration : IEntityTypeConfiguration<DetallesVenta>
    {
        public void Configure(EntityTypeBuilder<DetallesVenta> builder)
        {
            builder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<int>("VentaId")
                        .HasColumnType("int");

            builder.Property<int>("ProductoId")
                .HasColumnType("int");

            builder.Property<int>("CantiProd")
                .HasColumnType("int");

            builder.Property<double>("VentaProductos")
                .HasColumnType("float");

            builder.HasKey("VentaId", "ProductoId");

            builder.HasIndex("ProductoId");

            builder.ToTable("DetallesVentas");
        }
    }
}
