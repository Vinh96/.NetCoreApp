using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPITest.Entities;
using WebAPITest.Controllers;
using AutoMapper;
using WebAPITest.Models;
using Moq;
using NUnit.Framework;
using WebAPITest.Service;
using Microsoft.AspNetCore.Mvc;

namespace test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public async Task ApiReturnListOfRestaunts() 
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDto>();
            });
            var mapper = mockMapper.CreateMapper();
            //Arrange
            var mockRepo = new Mock<IRestaurantService>();
            mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(GetTestSession());
            var controller = new RestaurantController(mapper, mockRepo.Object);

            //Act 
            var result = await controller.getRestaurants();
            Assert.IsAssignableFrom<IEnumerable<RestaurantDto>>(result.Result);
        
            
        }
        private List<Restaurant> GetTestSession() {
            var session = new List<Restaurant>();
            session.Add(new Restaurant()
            {
                Id = 1,
                Name ="Pizza Hut",
                Description ="Pizza",

            });
            session.Add(new Restaurant()
            {
                Id =2,
                Name = "Pizza Company",
                Description = "Pizza"

            });
            return session;
        }
        
    }
}
