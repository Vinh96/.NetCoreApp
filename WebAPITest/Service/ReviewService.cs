using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Entities;
using WebAPITest.Repo;

namespace WebAPITest.Service
{
    public class ReviewService : BaseService<Review>, IReviewService
    {
        public ReviewService(IRepositoryBase<Review> baseRepository) : base(baseRepository)
        {
        }

        public async Task<IEnumerable<Review>> GetRestaurantReviews(int restaurantId)
        {
            var reviews = await GetByCondition(q => q.RestaurantId ==restaurantId);
            return reviews;
        }
    }
}
