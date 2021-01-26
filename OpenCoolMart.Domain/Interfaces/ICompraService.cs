using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ICompraService
    {
        public Task CrearVerta(Compra venta);
        public Task<Compra> VerVenta(int id);
        public IEnumerable<Venta> GetVentas(VentaQueryFilter filter);
    }
}
