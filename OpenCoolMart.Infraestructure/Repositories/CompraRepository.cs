using Microsoft.EntityFrameworkCore;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Domain.QueryFilters;
using OpenCoolMart.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Infraestructure.Repositories
{
    public class CompraRepository : SQLRepository<Compra>, ICompraRepository
    {
        private readonly OpenCoolMartContext _context;
        public CompraRepository(OpenCoolMartContext context):base(context)
        {
            _context = context;
        }

        public async Task CrearCompra(Compra compra)
        {
            Producto producto = new Producto();
            _context.Add(compra);
            foreach (var detalles in compra.CompraProductos)
            {
                producto = _context.Productos.AsNoTracking().SingleOrDefault(x => x.Id == detalles.ProductoId);
                _context.Add(detalles);
                producto.Stock = producto.Stock + detalles.CantidadProducto;
                
                _context.Productos.Update(producto);
            }
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Compra> GetCompras(CompraQueryFilter filter)
        {
            Expression<Func<Compra, bool>> expression = compra => compra.Id > 0;
            if (!string.IsNullOrEmpty(filter.Proveedor) && !string.IsNullOrWhiteSpace(filter.Proveedor))
            {
                Expression<Func<Proveedor, bool>> expr = proveedor => proveedor.Nombre == filter.Proveedor;
                var proveedores = _context.Proveedors.Where(expr)
               .Include(x => x.Compra).Select(x => x.Compra);
                return proveedores.Where(expression).AsEnumerable();
            }
            var compras =_context.Compras.Include(x => x.Proveedor).AsEnumerable();
            return compras;
        }

        public async Task<Compra> VerCompra(int id)
        {
            return await _context.Set<Compra>().Include(x => x.CompraProductos).ThenInclude(y => y.Producto).SingleOrDefaultAsync(x => x.Id == id);
        }
    }

    
}
