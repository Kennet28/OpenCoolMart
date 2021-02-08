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
        public Task CrearCompra(Compra compra);
        public Task<Compra> VerCompra(int id);
        public IEnumerable<Compra> GetCompras(CompraQueryFilter filter);
    }
}
