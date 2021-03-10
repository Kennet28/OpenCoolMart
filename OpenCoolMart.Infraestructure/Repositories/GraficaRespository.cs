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
            Expression<Func<DetallesVenta, bool>> expression = venta => venta.Venta.Id > 0;
            if(!string.IsNullOrEmpty(filter.Mes) && !string.IsNullOrWhiteSpace(filter.Mes)) {
                Expression<Func<DetallesVenta, bool>> expr = grafica => grafica.Venta.FechaVenta.Month.ToString() == filter.Mes;
                expression = expression.And(expr);
            }
            if (!string.IsNullOrEmpty(filter.Anio) && !string.IsNullOrWhiteSpace(filter.Anio))
            {
                Expression<Func<DetallesVenta, bool>> expr = grafica => grafica.Venta.FechaVenta.Year.ToString() == filter.Anio;
                expression = expression.And(expr);
            }
            var productos = _context.DetallesVentas.Include(x=>x.Producto).Where(expression).ToList();
            var contador = 0;
            var graficas = new List<Grafica>();
            foreach(var prodto in productos)
            {                
                var grafica = new Grafica();
                grafica.Producto = prodto.Producto.Descripcion;
                grafica.CantidadProducto = prodto.CantiProd;
                if (graficas.Any(x=>x.Producto==grafica.Producto))
                {
                    contador--;
                    graficas[contador].CantidadProducto = graficas[contador].CantidadProducto + grafica.CantidadProducto;
                    
                }
                else
                {
                    graficas.Add(grafica);
                }
                contador++;
            }
            return graficas.OrderByDescending(x=>x.CantidadProducto).Take(10);
        }
    }
}
