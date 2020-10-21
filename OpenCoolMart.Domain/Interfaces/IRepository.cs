using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Delete(int id);
        Task Update(T entity);
    }
}
