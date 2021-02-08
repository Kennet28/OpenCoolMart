using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IProductoService
    {
        Task AddProducto(Producto producto);
        Task DeleteProducto(int id);
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task UpdateProducto(Producto producto);
    }
}
