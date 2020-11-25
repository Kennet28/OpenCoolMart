using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IVentaService
    {
        public Task CrearVerta(Venta venta);
        public Task<Venta> VerVenta(int id);
        Task<IEnumerable<Venta>> GetVentas();
    }
}
