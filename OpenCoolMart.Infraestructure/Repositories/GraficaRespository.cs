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
    public class GraficaRespository :IGraficaRepository
    {
        private readonly OpenCoolMartContext _context;
        private DbSet<Grafica> _entities;
        public GraficaRespository(OpenCoolMartContext context) 
        {
            _context = context;
            this._entities = context.Set<Grafica>();
        }
        public IQueryable<Grafica> FindByCondition(Expression<Func<Grafica, bool>> expression)
        {
            return _entities.Where(expression).AsNoTracking().AsQueryable();
        }

        public IEnumerable<Grafica> GetAll(GraficaQueryFilter filter)
        {
            Expression<Func<Venta, bool>> expression = venta => venta.Id > 0;
            if(!string.IsNullOrEmpty(filter.Mes) && !string.IsNullOrWhiteSpace(filter.Mes)) {
                Expression<Func<Venta, bool>> expr = grafica => grafica.FechaVenta.Month.ToString() == filter.Mes;
                expression = expression.And(expr);
            }
            if (!string.IsNullOrEmpty(filter.Anio) && !string.IsNullOrWhiteSpace(filter.Anio))
            {
                Expression<Func<Venta, bool>> expr = grafica => grafica.FechaVenta.Year.ToString() == filter.Anio;
                expression = expression.And(expr);
            }
            var ventas = _context.Ventas.Include(x => x.DetallesVentas).ThenInclude(y => y.Producto).Where(expression)
                .AsEnumerable().Select(x => x.DetallesVentas);
            var detallesVentas = new List<DetallesVenta>();
            var graficas = new List<Grafica>();
            
            foreach (var venta in ventas)
                foreach (var detalle in venta)
                    detallesVentas.Add(detalle);
            
            foreach(var detallesventa in detallesVentas.GroupBy(x=>x.Producto.Descripcion))
            {
                var grafica = new Grafica();
                grafica.Producto = detallesventa.Key;
                grafica.CantidadProducto = detallesventa.Count();
                graficas.Add(grafica);
                if (graficas.Count >= 10)
                    break;
            }
            return graficas;
        }
    }
}
