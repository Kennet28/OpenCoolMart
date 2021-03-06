﻿using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IRepository<Producto> ProductoRepository { get; }
        public IVentaRepository VentaRepository { get;}
        public ISettingsRepository SettingsRepository { get;}
        public IRepository<Cliente> ClienteRepository { get;}
        public IRepository<Caja> CajaRepository { get;}
        public IRepository<Empleado> EmpleadoRepository { get; }
        // public IRepository<Facturas> FacturaRepository { get;}
        public IRepository<Usuario> UsuarioRepository { get; }
        public ICompraRepository CompraRepository { get; }
        public IRepository<Proveedor> ProveedorRepository { get; }
        public IGraficaRepository GraficaRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
