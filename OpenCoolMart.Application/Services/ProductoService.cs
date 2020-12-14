using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddProducto(Producto producto)
        {
            Expression<Func<Producto, bool>> expression = item => item.CodigoProducto == producto.CodigoProducto;
            var productos = _unitOfWork.ProductoRepository.FindByCondition(expression);
            if (productos.Any(item => item.CodigoProducto == producto.CodigoProducto))
                throw new Exception("Este codigo ya ha sido registrado");


            await _unitOfWork.ProductoRepository.Add(producto);
        }

        public async Task DeleteProducto(int id)
        {
            await _unitOfWork.ProductoRepository.Delete(id);
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _unitOfWork.ProductoRepository.GetAll();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _unitOfWork.ProductoRepository.GetById(id);
        }

        public async Task UpdateProducto(Producto producto)
        {
            Expression<Func<Producto, bool>> expression = item => item.CodigoProducto == producto.CodigoProducto;
            var productos = _unitOfWork.ProductoRepository.FindByCondition(expression);
            Expression<Func<Producto, bool>> expressionId = item => item.CodigoProducto == producto.CodigoProducto;
            var productosId = _unitOfWork.ProductoRepository.FindByCondition(expression);
            if (productos.Any(item => item.CodigoProducto == producto.CodigoProducto) && productos.All(item=>item.Id!=producto.Id))
                throw new Exception("Este codigo ya ha sido registrado");
            await _unitOfWork.ProductoRepository.Update(producto);
        }
    }
}
