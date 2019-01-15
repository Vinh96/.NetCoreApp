using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Entities;

namespace WebAPITest.Repo
{
    public class RestaurantRepo : RepositoryBase<Restaurant>, IRestaurantRepo 
    {
        public RestaurantRepo(RestaurantDbContext context) : base(context)
        {
        }
    }
}
