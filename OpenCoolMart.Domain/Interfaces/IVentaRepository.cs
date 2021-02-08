using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IVentaRepository:IRepository<Venta>
    {
        public IEnumerable<Venta> GetVentas(VentaQueryFilter filter);
        public Task CrearVerta(Venta venta);
        public Task<Venta> VerVenta(int id);
    }
}
