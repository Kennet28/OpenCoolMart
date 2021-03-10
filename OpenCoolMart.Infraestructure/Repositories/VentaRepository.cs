using LinqKit;
using Microsoft.EntityFrameworkCore;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Domain.QueryFilters;
using OpenCoolMart.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OpenCoolMart.Infraestructure.Repositories
{
    public class VentaRepository : SQLRepository<Venta>, IVentaRepository
    {
        private readonly OpenCoolMartContext _context;
        private DbSet<Producto> _producto;
        public VentaRepository(OpenCoolMartContext context):base(context)
        {
            _context = context;
            this._producto = _context.Set<Producto>();
        }
        public async Task CrearVerta(Venta venta)
        {
            _context.Add(venta);
            Producto producto = new Producto();
            
            foreach(var detalles in venta.DetallesVentas)
            {
                producto =_producto.AsNoTracking().SingleOrDefault(x => x.Id == detalles.ProductoId);
                _context.Add(detalles);
                producto.Stock = producto.Stock - detalles.CantiProd;
                if (producto.Stock <= 0)
                    throw new Exception($"No quedan stock suficiente para vender el producto {producto.Descripcion}");
                _producto.Update(producto);                
            }
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Venta> GetVentas(VentaQueryFilter filter)
        {
            Expression<Func<Venta, bool>> expression = animal => animal.Id > 0;

            if (filter.Folio.HasValue)
            {
                Expression<Func<Venta, bool>> expr = venta=>venta.Folio == filter.Folio.Value;
                expression = expression.And(expr);
            }
            if (filter.NumVenta.HasValue)
            {
                Expression<Func<Venta, bool>> expr = venta => venta.Id == filter.NumVenta.Value;
                expression = expression.And(expr);
            }
            var ventas = _context.Ventas.Include(x => x.Empleado).Where(expression).AsEnumerable();
            return ventas;
        }

        public async Task<Venta> VerVenta(int id)
        {
            return await _context.Set<Venta>().Include(x => x.DetallesVentas).ThenInclude(y => y.Producto).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
