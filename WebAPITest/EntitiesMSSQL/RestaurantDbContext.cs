using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Entities
{
    public class RestaurantDbContext : DbContext
    {
        
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) {
            Database.EnsureCreated();
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
    
}
