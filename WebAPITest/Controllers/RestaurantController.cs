using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebAPITest.Entities;
using WebAPITest.Models;
using WebAPITest.Service;

namespace WebAPITest.Controllers
{
   [Route("api/[controller]")]
   [Produces("application/json")]
    public class RestaurantController : Controller
    {
        private readonly IMapper _mapper;
        private IRestaurantService _restaurantService;
        private IReviewService _reviewService;
        private RestaurantDbContext _context; 
        public RestaurantController( IMapper mapper, IRestaurantService restaurantService,IReviewService reviewService,RestaurantDbContext context)
        {
            _mapper = mapper;
            _restaurantService = restaurantService;
            _reviewService = reviewService;
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Restaurant>>> getRestaurants()
        {
            var restaurantList = await _restaurantService.GetAllRestaurantObject();
            var restaurants = _mapper.Map<List<RestaurantDto>>(restaurantList);
            //var result = from r in _context.Restaurants
            //             select r;
            // var sql = ((System.Data.Entity.Core.Objects.ObjectQuery)result).ToTraceString();

            return Ok(restaurants);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> getRestaurant(int id)
        {

            var item = await _restaurantService.GetById(id);
            
            var result = _mapper.Map<RestaurantDto>(item);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{restaurantId}/reviews")]
        public async Task<ActionResult<IEnumerable<Review>>> getReviews (int restaurantId){
            var reviewList = await _reviewService.GetRestaurantReviews(restaurantId);
            return Ok(reviewList);
        }
        [HttpPost]
        public async Task<ActionResult<Restaurant>> createRestaurant([FromBody]Restaurant restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                await _restaurantService.CreateAsync(restaurant);
                return CreatedAtAction("getRestaurant", new { id = restaurant.Id }, restaurant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
          
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurant>> editRestaurant([FromBody]Restaurant restaurant,int id) {
            var currentRestaurant = await _restaurantService.GetById(id);
            _mapper.Map(restaurant, currentRestaurant);
            currentRestaurant.JsonData = JsonConvert.SerializeObject(currentRestaurant.JsonData);
            await _restaurantService.UpdateAsync(currentRestaurant);
            return Ok(currentRestaurant);
        }
    }
}