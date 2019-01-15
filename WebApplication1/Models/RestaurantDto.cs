using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VS2017Apps.Entities;

namespace VS2017Apps.Models
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfReviews { get; set; }

    }
}
