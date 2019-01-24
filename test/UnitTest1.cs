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
using System.Linq;

namespace test
{
    [TestFixture]
    public class UnitTest1
    {

        private readonly Mock<IRestaurantService> restaurantServiceMock;
        private IMapper mapper;

        public UnitTest1() {
            restaurantServiceMock = new Mock<IRestaurantService>();
            mapper = SetUpMockAutoMapperForRestaurantController();
        }
        [Test]
        public async Task RestaurantController_GetRestaurantList_ReturnStatusCode() 
        {
        
            //Arrange
            restaurantServiceMock.Setup(repo => repo.GetAllRestaurantObject())
                .Returns(Task.FromResult(GetTestSession()));

            var controller = new RestaurantController(mapper, restaurantServiceMock.Object);


            //Act 
            var result = await controller.getRestaurants();
            var okObject = result.Result as OkObjectResult;
            var model = okObject.Value as List<RestaurantDto>;


            //Assert
            Assert.AreEqual(2, model.Count());
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }
        [Test]
        public async Task RestaurantController_GetSingleRestaurant() {
            restaurantServiceMock.Setup(repo => repo.GetById(1)) 
                .ReturnsAsync(GetTestSession().Where(p=>p.Id.Equals(1)).FirstOrDefault());

            var controller = new RestaurantController(mapper, restaurantServiceMock.Object);

            //Act 
            var result = await controller.getRestaurant(1);
            var okObject = result.Result as OkObjectResult;
            var model = okObject.Value as RestaurantDto;

            Assert.AreEqual("Pizza Hut", model.Name);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }
        [Test]
        public async Task RestaurantController_CreateRestaurantSuccess() {
            //Arange
            var restaurant = new Restaurant();
            var controller = new RestaurantController(mapper, restaurantServiceMock.Object);
            //Act
            var result = await controller.createRestaurant(restaurant);
            var objectResult = result.Result as CreatedAtActionResult;

            Assert.IsInstanceOf<CreatedAtActionResult>(objectResult);
           
            restaurantServiceMock.Verify(repo => repo.CreateAsync(restaurant), Times.Once);
        }
        [Test]
        public async Task RestaurantController_CreateRestaurantFailed_ModelStateIsInvalid()
        {
            var controller = new RestaurantController(mapper, restaurantServiceMock.Object);
            controller.ModelState.AddModelError("Error", "Unit test error ");

            //Act
            var result = await controller.createRestaurant(new Restaurant());

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
        [Test]
        public async Task UpdateRestaurant_GetSingleRestaurant_ReturnSuccess() {
            var restaurant = GetTestSession().Where(r => r.Id.Equals(1)).SingleOrDefault();
            restaurantServiceMock.Setup(r => r.GetById(1)).ReturnsAsync(restaurant);
            var controller = new RestaurantController(mapper, restaurantServiceMock.Object);
            restaurantServiceMock.Setup(r => r.UpdateAsync(restaurant)).Returns(Task.CompletedTask).Verifiable();

            var result = await controller.editRestaurant(new Restaurant(),1);
            var okObjectResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
         
        }

        private IMapper SetUpMockAutoMapperForRestaurantController() {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Restaurant, RestaurantDto>();
            });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }
        private IEnumerable<Restaurant> GetTestSession() {
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
