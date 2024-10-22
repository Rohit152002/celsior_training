﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Repositories;

namespace WebAPIWithDatabaseTest
{
     internal class UserRepositoryTest
    {
        DbContextOptions options;
        ShoppingContext context;
        UserRepository repository;
        Mock<ILogger<UserRepository>> logger;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
                .UseInMemoryDatabase("TestAdd")
                .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<UserRepository>>();
            repository = new UserRepository(context, logger.Object);

        }
        [Test]
        public async Task TestAddUser()
        {
            User user = new User
            {
                Username = "TestUser",
                Password=Encoding.UTF8.GetBytes("TestPassword"),
                HashKey=Encoding.UTF8.GetBytes("TestHashKey"),
                Role=Roles.Admin,
            };

            var adduser= await repository.Add(user);
            Assert.IsTrue(adduser.Username == user.Username);

        }

    }
}