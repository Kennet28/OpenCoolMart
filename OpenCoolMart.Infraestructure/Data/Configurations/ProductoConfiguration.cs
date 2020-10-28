using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenCoolMart.Domain.Entities;
using System;


namespace OpenCoolMart.Infraestructure.Data.Configurations
{
    class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

            builder.Property<int>("CodigoProducto")
                .HasColumnType("int");

            builder.Property<DateTime>("CreateAt")
                .HasColumnType("datetime2");

            

            builder.Property<string>("Descripcion")
                .HasColumnType("nvarchar(max)");

            builder.Property<string>("Marca")
                .HasColumnType("nvarchar(max)");

            builder.Property<double>("Precio")
                .HasColumnType("float");

            builder.Property<bool>("Status")
                .HasColumnType("builderit");

            builder.Property<int>("Stock")
                .HasColumnType("int");

            builder.Property<DateTime?>("UpdateAt")
                .HasColumnType("datetime2");

            

            builder.HasKey("Id");

            builder.ToTable("Productos");
        }
    }
}
