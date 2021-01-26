using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IProveedorService
    {
        Task AddProveedor(Proveedor proveedor);
        Task DeleteProveedor(int id);
        Task<IEnumerable<Proveedor>> GetProveedores();
        Task<Proveedor> GetProveedor(int id);
        Task UpdateProveedor(Proveedor proveedor);
    }
}
