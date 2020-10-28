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
        private readonly IRepository<Venta> _ventaRepository;

        public UnitOfWork(OpenCoolMartContext context)
        {
            this._context = context;
        }

        public IRepository<Producto> ProductoRepository => _productoRepository ?? new SQLRepository<Producto>(_context);
        public IRepository<Venta> VentaRepository => _ventaRepository ?? new SQLRepository<Venta>(_context);        

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
