using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Controllers;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Models.DTO;
using WebAPIWithDatabase.Repositories;
using WebAPIWithDatabase.Services;


namespace WebAPIWithDatabaseTest
{
    internal class UserControllerTest
    {
        DbContextOptions options;
        ShoppingContext context;
        UserRepository repository;
        UserController controller;
        UserService service;
        Mock<ILogger<UserRepository>> loggerUserRepo;
        Mock<ILogger<UserService>> loggerUserService;
        Mock<ILogger<UserController>> loggerUserControllerRepo;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
            .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            loggerUserRepo = new Mock<ILogger<UserRepository>>();
            loggerUserService = new Mock<ILogger<UserService>>();
            loggerUserControllerRepo = new Mock<ILogger<UserController>>();
            repository = new UserRepository(context, loggerUserRepo.Object);
            service = new UserService(repository, loggerUserService.Object);
            controller = new UserController(service, loggerUserControllerRepo.Object);
        }

        [Test]
        [TestCase("rohit","intel",Roles.Admin)]
        public async Task TestRegister(string name,string password, Roles roles)
        {
            UserCreateDTO user = new UserCreateDTO
            { 
                UserName=name,
                Password=password,
                Roles=roles
            };

            var responseDTO=await controller.Register(user);

            Assert.IsNotNull(responseDTO);
            Console.WriteLine("fahsdlfj");
            System.Console.WriteLine("fklsajdf");
            var resultObject = responseDTO.Result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
            

        }

        [Test]
        [TestCase("rohit", "intel", Roles.Admin)]
        public async Task LoginTest(string name , string password,Roles roles)
        {
            UserCreateDTO user = new UserCreateDTO
            {
                UserName = name,
                Password = password,
                Roles = roles
            };

              await controller.Register(user);

            LoginRequestDTO userLogin = new LoginRequestDTO
            {
                Username = name,
                Password = password
            };

            var responseDTO = await controller.Login(userLogin);
            Assert.IsNotNull(responseDTO);
            var result = responseDTO as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
