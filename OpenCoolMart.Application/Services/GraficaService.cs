using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    class GraficaService : IGraficaService
    {
        private IUnitOfWork _unitOfWork;
        public GraficaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IQueryable<Grafica> FindByCondition(Expression<Func<Grafica, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grafica> GetAll(GraficaQueryFilter filter)
        {
            return _unitOfWork.GraficaRepository.GetAll(filter);
        }
    }
}
