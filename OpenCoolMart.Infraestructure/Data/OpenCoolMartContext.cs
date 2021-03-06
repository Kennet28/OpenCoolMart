﻿using Microsoft.EntityFrameworkCore;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Infraestructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Infraestructure.Data
{
    public class OpenCoolMartContext:DbContext
    {
        //public OpenCoolMartContext()
        //{

        //}
        public OpenCoolMartContext(DbContextOptions<OpenCoolMartContext> options) : base(options)
        {
        }
        
        DbSet<Permiso> Permisos { get; set; }
        DbSet<Perfil> Perfils { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Empleado> Empleados { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetallesVenta> DetallesVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        //DbSet<Caja> Cajas { get; set; }     
        // DbSet<Facturas> Facturas { get; set; }
        DbSet<Respaldos> Respaldo { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        DbSet<CompraProducto> CompraProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallesVenta>().HasKey(x => new { x.VentaId, x.ProductoId });
            modelBuilder.Entity<CompraProducto>().HasKey(x => new { x.CompraId, x.ProductoId });
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new DetallesVentaConfiguration());
            modelBuilder.ApplyConfiguration(new VentaConfiguration());
            // modelBuilder.ApplyConfiguration(new FacturaConfiguration());
        }
    }
}
