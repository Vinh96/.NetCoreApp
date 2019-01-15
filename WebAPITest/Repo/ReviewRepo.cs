using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Entities;

namespace WebAPITest.Repo
{
    public class ReviewRepo : RepositoryBase<Review>, IReviewRepo
    {
        public ReviewRepo(RestaurantDbContext context) : base(context)
        {
        }
    }
}
