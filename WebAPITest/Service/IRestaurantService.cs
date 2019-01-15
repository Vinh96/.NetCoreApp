using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Entities;
using WebAPITest.Models;

namespace WebAPITest.Service
{
    public interface IRestaurantService : IBaseService<Restaurant>
    {
        Task<Restaurant> GetById(int Id);
        Task<IEnumerable<RestaurantDto>> GetAllRestaurantObject();
    }
}
