using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models.DTO;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Repositories;
using WebAPIWithDatabase.Services;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace WebAPIWithDatabase
{
    public class ProductServiceTest
    {
        DbContextOptions<ShoppingContext> options;
        ShoppingContext context;
        ProductRepository repository;
        Mock<ILogger<ProductRepository>> logger;
        Mock<IMapper> mapper;
       


        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
              .UseInMemoryDatabase("testadd" + Guid.NewGuid())
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<ProductRepository>>();

            repository = new ProductRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddNewProductTest()
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
            IProductService productService = new ProductService(repository, mapper.Object);
            // Act
            var result = await productService.AddNewProduct(product);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        [TestCase("TestAdd1", 120, 4, "", "Test description for Product", 1)]

        public async Task GetAllProductTest(string name, float price, int quantity, string image, string desc, int id)
        {
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
            mapper.Setup(m => m.Map<Product>(product)).Returns(productEntity);
            IProductService productService = new ProductService(repository, mapper.Object);

            var result = await productService.AddNewProduct(product);
            var products = await productService.ViewAllProducts();
            Assert.NotNull(products);
        }

        [Test]
        [TestCase(1)]
        public async Task GetProductByIdTest(int productId)
        {
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
            mapper.Setup(m => m.Map<Product>(product)).Returns(productEntity);
            IProductService productService = new ProductService(repository, mapper.Object);

            var result = await productService.AddNewProduct(product);
            var getProduct = await productService.GetProductById(productId);
            Assert.NotNull(getProduct);
        }
    }
}
