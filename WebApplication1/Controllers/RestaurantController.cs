using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VS2017Apps.Entities;
using VS2017Apps.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public RestaurantController(RestaurantDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Restaurant>>> getRestaurants()
        {
            //var result = _mapper.Map<RestaurantDto>(_context.Restaurants.);
            List<Restaurant> restaurantList = _context.Restaurants.ToList();
            var restaurants =  _mapper.Map<List<RestaurantDto>>(restaurantList);
            return Ok(restaurants);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> getRestaurant(int id ) {

            var item = await _context.Restaurants.FindAsync(id);
            var result = _mapper.Map<RestaurantDto>(item);
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Restaurant>> createRestaurant([FromBody]Restaurant restaurant) {
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
                return CreatedAtAction("getRestaurant", new { id = restaurant.Id },restaurant);
        }
    }

}
