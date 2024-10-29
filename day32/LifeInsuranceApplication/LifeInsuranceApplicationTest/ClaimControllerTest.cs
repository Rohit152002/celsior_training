using System.Net;
using AutoMapper;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Controllers;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace LifeInsuranceApplicationTest
{
    public class ClaimControllerTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimRepository repository;
        ClaimService service;
        ClaimController controller;
        Mock<ILogger<ClaimRepository>> logger;
        Mock<IMapper> mapper;
        string uploadFolder;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
            .UseInMemoryDatabase("testAdd" + Guid.NewGuid())
            .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimRepository>>();
            mapper = new Mock<IMapper>();
            repository = new ClaimRepository(context, logger.Object);
            uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            service = new ClaimService(repository, uploadFolder, mapper.Object);
            controller = new ClaimController(service);
        }
        //        public async Task<ActionResult> ClaimNewAsync([FromForm] ClaimDTO claimDTO)

        [Test]
        public async Task TestClaimRequest()
        {
            var formFile = new Mock<IFormFile>();
            var fileName = "testfile.jpg";
            var fileContent = "This is a test file content";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(fileContent);
            writer.Flush();
            stream.Position = 0; // Reset stream position

            formFile.Setup(f => f.Length).Returns(stream.Length);
            formFile.Setup(f => f.FileName).Returns(fileName);
            formFile.Setup(f => f.OpenReadStream()).Returns(stream);
            formFile.Setup(f => f.ContentType).Returns("image/jpeg");



            ClaimDTO claimDTO = new ClaimDTO
            {
                PolicyId = 1, // Example policy ID
                ClaimTypeId = 1, // Example claim type ID
                DateOfIncident = DateTime.Now,
                ClaimantName = "John Doe",
                ClaimantPhone = "1234567890",
                ClaimantEmail = "john.doe@example.com",
                SettleForm = formFile.Object, // Assuming you don't need this for the test
                DeathCertificateForm = formFile.Object,
                PolicyCertificateForm = formFile.Object,
                Photo = formFile.Object,
                AddressProof = formFile.Object,
                CancelCheck = formFile.Object,
                Other = formFile.Object // 
            };

            var result = await controller.ClaimNewAsync(claimDTO);
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
        [Test]
        public async Task TestExceptionTestClaimRequest()
        {
            var formFile = new Mock<IFormFile>();
            var fileName = "testfile.jpg";
            var fileContent = "This is a test file content";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(fileContent);
            writer.Flush();
            stream.Position = 0; // Reset stream position

            formFile.Setup(f => f.Length).Returns(stream.Length);
            formFile.Setup(f => f.FileName).Returns(fileName);
            formFile.Setup(f => f.OpenReadStream()).Returns(stream);
            formFile.Setup(f => f.ContentType).Returns("image/jpeg");



            ClaimDTO claimDTO = new ClaimDTO
            {
                PolicyId = 1, // Example policy ID
                ClaimTypeId = 1, // Example claim type ID
                DateOfIncident = DateTime.Now,
                ClaimantName = null,
                ClaimantPhone = "1234567890",
                ClaimantEmail = "john.doe@example.com",
                SettleForm = formFile.Object, // Assuming you don't need this for the test
                DeathCertificateForm = formFile.Object,
                PolicyCertificateForm = formFile.Object,
                Photo = formFile.Object,
                AddressProof = formFile.Object,
                CancelCheck = formFile.Object,
                Other = formFile.Object // 
            };

            var result = await controller.ClaimNewAsync(claimDTO);
            // Assert
            Assert.IsNotNull(result);
            var resultObject = result as ObjectResult; // Use ObjectResult for BadRequest
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(StatusCodes.Status400BadRequest, resultObject.StatusCode);
        }
        //        public async Task<ActionResult> GetClaimAsync()

        [Test]
        public async Task TestGetClaim()
        {
            var formFile = new Mock<IFormFile>();
            var fileName = "testfile.jpg";
            var fileContent = "This is a test file content";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(fileContent);
            writer.Flush();
            stream.Position = 0; // Reset stream position

            formFile.Setup(f => f.Length).Returns(stream.Length);
            formFile.Setup(f => f.FileName).Returns(fileName);
            formFile.Setup(f => f.OpenReadStream()).Returns(stream);
            formFile.Setup(f => f.ContentType).Returns("image/jpeg");



            ClaimDTO claimDTO = new ClaimDTO
            {
                PolicyId = 1, // Example policy ID
                ClaimTypeId = 1, // Example claim type ID
                DateOfIncident = DateTime.Now,
                ClaimantName = "John Doe",
                ClaimantPhone = "1234567890",
                ClaimantEmail = "john.doe@example.com",
                SettleForm = formFile.Object, // Assuming you don't need this for the test
                DeathCertificateForm = formFile.Object,
                PolicyCertificateForm = formFile.Object,
                Photo = formFile.Object,
                AddressProof = formFile.Object,
                CancelCheck = formFile.Object,
                Other = formFile.Object // 
            };

            var result = await controller.ClaimNewAsync(claimDTO);

            var response = await controller.GetClaimAsync();
            var resultObject = response as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }

        [Test]
        public async Task TestExceptionGetClaim()
        {
                // service.Setup(m => m.GetClaims()).ThrowsAsync(new Exception(exceptionMessage));
            var response = await controller.GetClaimAsync();
            Assert.IsNotNull(response);
            var resultObject = response as ObjectResult; // Use ObjectResult for BadRequest
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(StatusCodes.Status400BadRequest, resultObject.StatusCode);
        }

    }
}