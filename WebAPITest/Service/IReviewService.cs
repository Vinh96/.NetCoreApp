using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Entities;

namespace WebAPITest.Service
{
   public interface IReviewService : IBaseService<Review>
    {
        Task<IEnumerable<Review>> GetRestaurantReviews(int restaurantId);
      
    }
}
