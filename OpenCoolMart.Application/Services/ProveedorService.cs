using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProveedorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProveedor(Proveedor proveedor)
        {
            await _unitOfWork.ProveedorRepository.Add(proveedor);
        }

        public async Task DeleteProveedor(int id)
        {
            await _unitOfWork.ProveedorRepository.Delete(id);
        }

        public async Task<Proveedor> GetProveedor(int id)
        {
            return await _unitOfWork.ProveedorRepository.GetById(id);
        }

        public async Task<IEnumerable<Proveedor>> GetProveedores()
        {
            return await _unitOfWork.ProveedorRepository.GetAll();
        }

        public async Task UpdateProveedor(Proveedor proveedor)
        {
            await _unitOfWork.ProveedorRepository.Update(proveedor);
        }
    }
}
