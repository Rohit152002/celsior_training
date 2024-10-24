using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Repositories;
using WebAPIWithDatabase.Services;
namespace WebAPIWithDatabaseTest
{
    public class Tests
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
        //[Test]
        //public async Task TestAdd()
        //{
        //    //Arrange
            
        //    //Act
        //    Product product = new Product
        //    {
        //        Name = "Product1",
        //        Price = 100,
        //        Quantity = 5,
        //        BasicImage = "",
        //        Description = "Test Product"
        //    };
        //    var result = await repository.Add(product);
        //    //Assert
        //    Assert.AreEqual(1, result.Id);
        //}

        //[Test]
        //[TestCase(10, 20, 30)]
        //[TestCase(int.MaxValue, -20, (int.MaxValue))]
        //public void AddTest(int n1, int n2, int result)
        //{
        //    // Arrange
        //    int num1 = n1, num2 = n2;
        //    CalculateService calculate = new CalculateService();
        //    // Act
        //    int actualResult = calculate.Add(num1, num2);
        //    // Assert
        //    Assert.AreEqual(result, actualResult);
        //}
    }
}