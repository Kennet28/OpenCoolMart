using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    public class VentaService : IVentaService
    {
        private IUnitOfWork _unitOfWork;
        public VentaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task CrearVerta(Venta venta)
        {
            await _unitOfWork.VentaRepository.Add(venta);
        }

        public Task<IEnumerable<Venta>> GetAll()
        {
            return _unitOfWork.VentaRepository.GetAll();
        }

        public Task<Venta> VerVenta(int id)
        {
            return _unitOfWork.VentaRepository.VerVenta(id);
        }
    }
}
