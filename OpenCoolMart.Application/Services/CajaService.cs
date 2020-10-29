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
    public class CajaService:ICajaService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public CajaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCaja(Caja caja)
        {
            Expression<Func<Caja, bool>> expression = item => item.Id == caja.Id;
            var cajas = await _unitOfWork.CajaRepository.FindByCondition(expression);
            if (cajas.Any(item => item.Id == caja.Id))
                throw new Exception("Este codigo ya ha sido registrado");


            await _unitOfWork.CajaRepository.Add(caja);
        }

        public async Task DeleteCaja(int id)
        {
            await _unitOfWork.CajaRepository.Delete(id);
        }

        public async Task<IEnumerable<Caja>> GetCajas()
        {
            return await _unitOfWork.CajaRepository.GetAll();
        }

        public async Task<Caja> GetCaja(int id)
        {
            return await _unitOfWork.CajaRepository.GetById(id);
        }

        public async Task UpdateCaja(Caja caja)
        {
            await _unitOfWork.CajaRepository.Update(caja);
        }
    }
}
