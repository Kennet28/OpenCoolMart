using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Infraestructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly OpenCoolMartContext _context;

        private readonly IRepository<Producto> _productoRepository;
        private readonly IVentaRepository _ventaRepository;
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IRepository<Facturas> _facturasRepository;
        private readonly IRepository<Empleado> _empleadoRepository;
        private readonly IRepository<Caja> _cajaRepository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public UnitOfWork(OpenCoolMartContext context)
        {
            this._context = context;
        }

        public IRepository<Producto> ProductoRepository => _productoRepository ?? new SQLRepository<Producto>(_context);
        public IVentaRepository VentaRepository => _ventaRepository ?? new VentaRepository(_context);

        public IRepository<Cliente> ClienteRepository => _clienteRepository ?? new SQLRepository<Cliente>(_context);
        public IRepository<Caja> CajaRepository => _cajaRepository ?? new SQLRepository<Caja>(_context);
        public IRepository<Empleado> EmpleadoRepository => _empleadoRepository ?? new SQLRepository<Empleado>(_context);
        public IRepository<Facturas> FacturaRepository => _facturasRepository ?? new SQLRepository<Facturas>(_context);

        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new SQLRepository<Usuario>(_context);

        public void Dispose()
        {
            if (_context == null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
