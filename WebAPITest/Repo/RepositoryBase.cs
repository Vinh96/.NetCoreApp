using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Entities;

namespace WebAPITest.Repo
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private RestaurantDbContext _context;
        public RepositoryBase(RestaurantDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
             _context.Set<T>().AddAsync(entity);
        }

        public  IQueryable<T>  FindAll()
        {
            return  _context.Set<T>();
        }

        public  IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return  _context.Set<T>().Where(expression);
        }

        public async Task SaveChangeAsync()
        {
             await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
