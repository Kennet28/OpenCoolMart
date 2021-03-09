using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IGraficaRepository 
    {
        IQueryable<Grafica> FindByCondition(Expression<Func<Grafica, bool>> expression);
        IEnumerable<Grafica> GetAll(GraficaQueryFilter filter);
    }
}
