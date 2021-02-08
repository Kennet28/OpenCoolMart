using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ICompraRepository : IRepository<Compra>
    {
        public Task CrearCompra(Compra compra);
        public IEnumerable<Compra> GetCompras(CompraQueryFilter filter);
        public Task<Compra> VerCompra(int id);
    }
}
