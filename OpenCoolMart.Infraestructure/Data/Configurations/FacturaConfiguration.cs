using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Infraestructure.Data.Configurations
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Facturas>
    {
        public void Configure(EntityTypeBuilder<Facturas> builder)
        {
            builder.Property<int>("Id")
                         .ValueGeneratedOnAdd()
                         .HasColumnType("int")
                         .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<int>("ClienteId")
                .HasColumnType("int");

            builder.Property<DateTime>("CreateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("CreatedBy")
                .HasColumnType("int");

            builder.Property<DateTime>("Fecha")
                .HasColumnType("datetime2");

            builder.Property<int>("Folio")
                .HasColumnType("int");

            builder.Property<string>("Observaciones")
                .HasColumnType("nvarchar(max)");

            builder.Property<bool>("Status")
                .HasColumnType("bit");

            builder.Property<DateTime?>("UpdateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("UpdatedBy")
                .HasColumnType("int");

            builder.Property<string>("UsoCFDI")
                .HasColumnType("nvarchar(max)");

            builder.Property<int>("VentaId")
                .HasColumnType("int");

            builder.HasKey("Id");

            builder.HasIndex("ClienteId");

            builder.HasIndex("VentaId");

            builder.ToTable("Facturas");
        }
    }
}
