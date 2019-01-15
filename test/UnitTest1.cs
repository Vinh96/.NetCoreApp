using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using WebAPITest.Repo;
using System.Collections.Generic;
using WebAPITest.Entities;
using WebAPITest.Controllers;
using AutoMapper;
using WebAPITest.Models;
using Microsoft.AspNetCore.Mvc;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public async Task ApiReturnListOfRestaunts() 
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDto>();
            });
            var mapper = mockMapper.CreateMapper();
            //Arrange
            var mockRepo = new Mock<IRestaurantRepo>();
            mockRepo.Setup(repo => repo.getRestaurants())
                .ReturnsAsync(GetTestSession());
            var controller = new RestaurantController(mapper, mockRepo.Object);

            //Act 
            var result = await controller.getRestaurants();
            //Assert 
            var type = Assert.IsType<OkObjectResult>(result.Result);
            
        }
        private List<Restaurant> GetTestSession() {
            var session = new List<Restaurant>();
            session.Add(new Restaurant()
            {
                Id = 1,
                Name ="Pizza Hut",
                Description ="Pizza"

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
