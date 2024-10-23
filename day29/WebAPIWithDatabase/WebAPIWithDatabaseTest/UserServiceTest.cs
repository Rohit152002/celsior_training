using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Models.DTO;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Repositories;
using WebAPIWithDatabase.Services;

namespace WebAPIWithDatabaseTest
{
    internal class UserServiceTest
    {
        DbContextOptions options;
        ShoppingContext context;
        UserRepository repository;
        Mock<ILogger<UserRepository>> loggerUserRepo;
        Mock<ILogger<UserService>> loggerUserService;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
            .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            loggerUserRepo = new Mock<ILogger<UserRepository>>();
            loggerUserService = new Mock<ILogger<UserService>>();
            repository = new UserRepository(context, loggerUserRepo.Object);
        }

        [Test]
        [TestCase("TestUser", "TestPassword", "TestHashKey", Roles.Admin)]
        public async Task TestAdd(string username, string password, string hashKey, Roles role)
        {
            var user = new UserCreateDTO
            {
                UserName = username,
                Password = password,
                Roles = role
                
            };
            var userService = new UserService(repository, loggerUserService.Object);
            var addedUser = await userService.Register(user);
            Assert.IsTrue(addedUser.Username == user.UserName);
        }

        [TestCase("TestUser", "TestPassword", "TestHashKey")]
        public async Task TestAuthenticate(string username, string password, string hashKey)
        {
            var user = new UserCreateDTO
            {
                UserName = "TestUser",
                Password = "TestPassword",
                Roles = Roles.Admin
            };
            var userService = new UserService(repository, loggerUserService.Object);
            var addedUser = await userService.Register(user);
            var loggedInUser = await userService.Autheticate(new LoginRequestDTO
            {
                Username = user.UserName,
                Password = user.Password
            });
            Assert.IsTrue(addedUser.Username == loggedInUser.Username);
        }
        
        


    }
}
