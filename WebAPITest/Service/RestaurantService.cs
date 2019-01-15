using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Entities;
using WebAPITest.Models;
using WebAPITest.Repo;

namespace WebAPITest.Service
{
    public class RestaurantService : BaseService<Restaurant>, IRestaurantService
    {
        private RestaurantDbContext _context;
        public RestaurantService(IRepositoryBase<Restaurant> baseRepository,RestaurantDbContext context) : base(baseRepository)
        {
            _context = context;
        }

        public async Task<Restaurant> GetById(int Id)
        {
           var result= await GetByCondition(q => q.Id.Equals(Id));
            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantObject() {
            var restaurants = await GetAllQuery().Select(p => new RestaurantDto
            {
                Id = p.Id,
                Name = p.Name,
                FoundedDate = p.FoundedDate,
                Description = p.Description,
                Reviews = p.Reviews.Where(r => r.Body != null),
                NumberOfReviews = p.Reviews.Count() 
            }).ToListAsync();

            return restaurants;
        }
    }
}
