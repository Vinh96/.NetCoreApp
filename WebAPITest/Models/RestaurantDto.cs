using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Entities;

namespace WebAPITest.Models
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FoundedDate { get; set; }
        public int NumberOfReviews { get; set; }
        public string JsonData { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
