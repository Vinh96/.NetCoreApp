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
        public RestaurantController( IMapper mapper, IRestaurantService restaurantService)
        {
            _mapper = mapper;
            _restaurantService = restaurantService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> getRestaurants()
        {
            var restaurantList = await _restaurantService.GetAllRestaurantObject();
            var result = _mapper.Map<List<RestaurantDto>>(restaurantList);   
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> getRestaurant(int id)
        {

            var item = await _restaurantService.GetById(id);
            
            var result = _mapper.Map<RestaurantDto>(item);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
      
        [HttpPost]
        public async Task<ActionResult<RestaurantDto>> createRestaurant([FromBody]Restaurant restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }   
                await _restaurantService.CreateAsync(restaurant);
                return CreatedAtAction("getRestaurants", restaurant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
          
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RestaurantDto>> editRestaurant([FromBody]Restaurant restaurant,int id) {
            var currentRestaurant = await _restaurantService.GetById(id);
            if (currentRestaurant == null) {
                return NotFound();
            }
            _mapper.Map(restaurant, currentRestaurant);
            await _restaurantService.UpdateAsync(currentRestaurant);
            return Ok(currentRestaurant);
        }
    }
}