using AutoMapper;
using Castle.Core.Logging;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsuranceApplicationTest
{
    internal class ClaimServiceTest
    {
        DbContextOptions options;
        InsuranceContext context;
       
        ClaimService service;
        Mock<ILogger<ClaimRepository>> logger;
        //Mock<IRepository<int, Claim>> repository;
        ClaimRepository repository;
        Mock<IMapper> mapper;
        string uploadFolder;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
                .UseInMemoryDatabase("testadd" + Guid.NewGuid())
                .Options;
            context = new InsuranceContext(options);
            mapper= new Mock<IMapper>();
            logger = new Mock<ILogger<ClaimRepository>>();
            //repository = new Mock<IRepository<int, Claim>>();
            repository = new ClaimRepository(context, logger.Object);
            uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            service = new ClaimService(repository, uploadFolder, mapper.Object);

        }

        [Test]
        public async Task TestAddClaim()
        {
            //Assert
            // Arrange
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
                SettleForm = null, // Assuming you don't need this for the test
                DeathCertificateForm = null,
                PolicyCertificateForm = null,
                Photo = null,
                AddressProof = null,
                CancelCheck = null,
                Other = formFile.Object // 
            };

            int id= await service.RequestNewClaim(claimDTO);
            Assert.AreEqual(1,id);

        }

        [Test]
        public async Task TestExceptionAddClaim()
        {
            var formFile = new Mock<IFormFile>();
            var fileName = "testfile.jpg";
            var fileContent = "This is a test file content";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(fileContent);
            writer.Flush();
            stream.Position = 0; 

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
                ClaimantPhone = null,
                ClaimantEmail = "john.doe@example.com",
                SettleForm = null, // Assuming you don't need this for the test
                DeathCertificateForm = null,
                PolicyCertificateForm = null,
                Photo = null,
            };

            Assert.ThrowsAsync<Exception>(async()=>await service.RequestNewClaim(claimDTO));
        }

        //        public async Task<IEnumerable<ClaimDTO>> GetClaims()
        [Test]
        public async Task TestGetClaims()
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
                SettleForm = null, // Assuming you don't need this for the test
                DeathCertificateForm = null,
                PolicyCertificateForm = null,
                Photo = null,
                AddressProof = null,
                CancelCheck = null,
                Other = formFile.Object // 
            };

            int id = await service.RequestNewClaim(claimDTO);

            var claims = await service.GetClaims();
            Assert.NotNull(claims);
        }

        [Test]
        public async Task TestExeptionGetAll()
        {
            Assert.ThrowsAsync<Exception>(async () => await service.GetClaims());
        }

    }
}
