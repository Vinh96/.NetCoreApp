using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int RestaurantId { get; set; }
    }
}
