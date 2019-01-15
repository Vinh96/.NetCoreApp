using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Repo;

namespace WebAPITest.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private IRepositoryBase<T> _baseRepository;

        public BaseService(IRepositoryBase<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task CreateAsync(T entity)
        {
            _baseRepository.Create(entity);
            await _baseRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable<T>>GetAll()
        {
            var result = await _baseRepository.FindAll().ToListAsync();
            return result;
        }

        public IQueryable<T> GetAllQuery()
        {
            var result =  _baseRepository.FindAll();
            return result;
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            var result = await _baseRepository.FindByCondition(expression).ToListAsync();
            return result;
        }

        public IQueryable<T> GetByConditionQuery(Expression<Func<T, bool>> expression)
        {
            var result = _baseRepository.FindByCondition(expression);
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _baseRepository.Update(entity);
            await _baseRepository.SaveChangeAsync();
        }
    }
}
