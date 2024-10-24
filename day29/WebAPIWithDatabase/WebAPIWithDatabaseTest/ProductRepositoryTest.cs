using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace WebAPIWithDatabaseTest
{
    internal class ProductRepositoryTest
    {

        DbContextOptions<ShoppingContext> options;
        ShoppingContext context;
        ProductRepository repository;
        Mock<ILogger<ProductRepository>> logger;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
              .UseInMemoryDatabase("testadd" + Guid.NewGuid())
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<ProductRepository>>();
            repository = new ProductRepository(context, logger.Object);
        }


        [Test]
        [TestCase("TestAdd1", 120, 4, "", "Test description for Product", 1)]
        //[TestCase("TestAdd2", 120, 4, "", "Test description for Product", 2)]
        public async Task TestAdd(string name, float price, int quantity, string image, string desc, int id)
        {
            //Arrange
            Product product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                BasicImage = image,
                Description = desc
            };
            //Act
            var result = await repository.Add(product);
            //Assert
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        [TestCase("TestAdd1", 120, 4, "", "Test description for Product", 1)]

        public async Task TestAddException(string name, float price, int quantity, string image, string desc, int id)
        {
            //Arrange
            Product product = new Product
            {
                Name = null,
                Price = price,
                Quantity = quantity,
                BasicImage = image,
                Description = desc
            };

            //Assert
            Assert.ThrowsAsync<Exception>(async () => await repository.Add(product));
            //Assert.ThrowsAsync<CouldNotAddException>(async () => await repository.Add(product));

        }

        [Test]
        [TestCase("TestAdd1", 120, 4, "", "Test description for Product", 1)]
        public async Task TaskGetAllProduct(string name, float price, int quantity, string image, string desc, int id)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                BasicImage = image,
                Description = desc
            };
            await repository.Add(product);
            var products = await repository.GetAll();
            Assert.NotNull(products);


        }
        [Test]
        [TestCase(1)]
        public async Task GetProductById(int productId)
        {
            Product product = new Product
            {
                Name = "Samsungl Galaxy J7",
                Price = 13000,
                Quantity = 2,
                BasicImage = "image.jpg",
                Description = "a legend mobile phone"
            };
            Product addedProduct = await repository.Add(product);
            var getProduct = await repository.Get(productId);
            Assert.AreEqual(productId,getProduct.Id);
        }

        [Test]
        public async Task GetAllProductException()
        {
            Assert.ThrowsAsync<Exception>(async () => await repository.GetAll());
        }

        [Test]
        public async Task GetProductByIDException()
        {
            var product = repository.Get(1);
            var exception = Assert.ThrowsAsync<Exception>(async () => await repository.Get(1));
            Assert.AreEqual("Product not available", exception.Message);
        }

        [Test]
        [TestCase(1)]
        public async Task Delete(int productId)
        {
            Product product = new Product
            {
                Name = "Samsungl Galaxy J7",
                Price = 13000,
                Quantity = 2,
                BasicImage = "image.jpg",
                Description = "a legend mobile phone"
            };
            Product addedProduct = await repository.Add(product);
            Product deletedProduct= await repository.Delete(productId);
            Assert.NotNull(deletedProduct);
        }
        [Test]
        [TestCase(1)]
        public async Task DeleteAsyncThrow(int productId)
        {
            Assert.ThrowsAsync<Exception>(async()=>await repository.Delete(productId));
        }

        [Test]
        [TestCase("TestAdd1", 120, 4, "", "Test description for Product", 1)]
        public async Task TaskGetUpdate(string name, float price, int quantity, string image, string desc, int id)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                BasicImage = image,
                Description = desc
            };
            Product addedProduct = await repository.Add(product);
            Product updateProduct = new Product
            {
                Name = name,
                Price = 1000,
                Quantity = quantity,
                BasicImage = image,
                Description = desc
            };
            var updated = await repository.Update(id, updateProduct);
            Assert.NotNull(updated);


        }


    }
}
