using Microsoft.EntityFrameworkCore;
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
            builder.ToTable("Facturas", "dbo");
            builder.HasIndex(e => e.Cliente.Id)
                   .HasName("IX_Facturas_ClienteId");

            builder.HasIndex(e => e.Venta.Id)
                .HasName("IX_Facturas_VentaId");

            builder.Property(e => e.UsoCFDI).HasColumnName("UsoCFDI");

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Factura)
                .HasForeignKey(d => d.Cliente.Id)
                .HasConstraintName("FK_Facturas_Clientes_ClienteId");

            builder.HasOne(d => d.Venta)
                .WithMany(p => p.Factura)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_Facturas_Ventas_VentaId");
        }
    }
}
