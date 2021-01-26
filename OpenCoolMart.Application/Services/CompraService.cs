using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    public class CompraService:ICompraService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Task CrearVerta(Compra venta)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venta> GetVentas(VentaQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<Compra> VerVenta(int id)
        {
            throw new NotImplementedException();
        }
    }
}
