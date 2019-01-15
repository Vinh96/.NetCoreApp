using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Entities;
using WebAPITest.Service;

namespace WebAPITest.Controllers
{
    [Route("api/restaurant/{restaurantId}/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private IReviewService _service;
        public ReviewController(IReviewService service)
        {
            _service = service; 
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody]Review review,[FromRoute] int restaurantId) {
            review.RestaurantId = restaurantId; 
            await _service.CreateAsync(review);
            return Ok(review);
        }
    }
}