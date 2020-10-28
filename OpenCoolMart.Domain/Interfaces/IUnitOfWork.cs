using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IRepository<Producto> ProductoRepository { get; }
        public IRepository<Venta> VentaRepository { get;}

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
