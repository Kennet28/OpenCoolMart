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
    public class FacturasService:IFacturasService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public FacturasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddFactura(Facturas Factura)
        {
            Expression<Func<Facturas, bool>> expression = item => item.Id == Factura.Id;
            var facturas = await _unitOfWork.FacturaRepository.FindByCondition(expression);
            if (facturas.Any(item => item.Id == Factura.Id))
                throw new Exception("Este factura ya ha sido registrado");
            await _unitOfWork.FacturaRepository.Add(Factura);
        }

        public async Task DeleteFactura(int id)
        {
            await _unitOfWork.FacturaRepository.Delete(id);
        }

        public async Task<IEnumerable<Facturas>> GetFacturas()
        {
            return await _unitOfWork.FacturaRepository.GetAll();
        }

        public async Task<Facturas> GetFactura(int id)
        {
            return await _unitOfWork.FacturaRepository.GetById(id);
        }

        public async Task UpdateFactura(Facturas Factura)
        {
            await _unitOfWork.FacturaRepository.Update(Factura);
        }
    }
}
