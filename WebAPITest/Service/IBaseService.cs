using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPITest.Service
{
    public interface IBaseService<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        IQueryable<T> GetAllQuery();
        IQueryable<T> GetByConditionQuery(Expression<Func<T, bool>> expression);
    }
}
