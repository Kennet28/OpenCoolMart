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

        public CompraService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CrearCompra(Compra compra)
        {
            
            await _unitOfWork.CompraRepository.CrearCompra(compra);
        }

        public IEnumerable<Compra> GetCompras(CompraQueryFilter filter)
        {
            var compras = _unitOfWork.CompraRepository.GetCompras(filter);
            return compras;
        }

        public async Task<Compra> VerCompra(int id)
        {
            return await _unitOfWork.CompraRepository.VerCompra(id);
        }

    }
}
