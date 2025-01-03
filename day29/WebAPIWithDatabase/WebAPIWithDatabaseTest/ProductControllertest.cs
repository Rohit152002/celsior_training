﻿using AutoMapper;
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
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models.DTO;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Repositories;
using WebAPIWithDatabase.Services;

namespace WebAPIWithDatabaseTest
{
    internal class ProductControllertest
    {
        DbContextOptions<ShoppingContext> options;
        ShoppingContext context;
        ProductRepository repository;
        Mock<ILogger<ProductRepository>> logger;
        private Mock<ILogger<ProductController>> loggerController;
        Mock<IMapper> mapper;
        IProductService productService;
        ProductDTO product;
        Product productEntity;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
              .UseInMemoryDatabase("testadd" + Guid.NewGuid())
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<ProductRepository>>();
            loggerController = new Mock<ILogger<ProductController>>();
            repository = new ProductRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
            productService = new ProductService(repository, mapper.Object);
        }

        [Test]
        public async Task AddProductTest()
        {
            // Arrange
            var product = new ProductDTO
            {
                Name = "Test Product",
                Price = 10.0f,
                Quantity = 100
            };
            var productEntity = new Product
            {
                Name = "Test Product",
                Price = 10.0f,
                Quantity = 100
            };
            mapper.Setup(m => m.Map<Product>(product)).Returns(productEntity);//dummying the method to return the result for testing
            var controller = new ProductController(productService, loggerController.Object);
            // Act
            var result = await controller.CreateProduct(product);
            Assert.IsNotNull(result);
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }

    }
}
