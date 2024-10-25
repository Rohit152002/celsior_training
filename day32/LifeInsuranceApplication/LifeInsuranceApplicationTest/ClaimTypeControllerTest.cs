using System.Security.Claims;
using AutoMapper;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Controllers;
using LifeInsuranceApplication.Models;
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
    public class ClaimTypeControllerTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimTypeRepository repository;
        ClaimTypeService service;
        ClaimTypeController controller;
        Mock<ILogger<ClaimTypeRepository>> logger;
        Mock<IMapper> mapper;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
            .UseInMemoryDatabase("testAdd" + Guid.NewGuid())
            .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimTypeRepository>>();
            mapper = new Mock<IMapper>();
            repository = new ClaimTypeRepository(context, logger.Object);
            service = new ClaimTypeService(repository, mapper.Object);
            controller = new ClaimTypeController(service);
        }

        //        public async Task<ActionResult> CreateClaimAsync(ClaimTypeDTO claimTypeDTO)


        [Test]
        public async Task TestCreateClaimType()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO
            {
                ClaimName = "Natural"
            };
            ClaimType claimEntity = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };
            mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);
            var result = await controller.CreateClaimAsync(claimTypeDTO);
            Assert.IsNotNull(result);

            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }

        [Test]
        public async Task TestExceptionCreatePolicy()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO
            {
                ClaimName = null
            };
            ClaimType claimEntity = new ClaimType
            {
                Id = 1,
                ClaimName = null
            };
            mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);
            var result = await controller.CreateClaimAsync(claimTypeDTO);
            Assert.IsNotNull(result);
            var resultObject = result as ObjectResult; // Use ObjectResult for BadRequest
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(StatusCodes.Status400BadRequest, resultObject.StatusCode);
        }
        //        public async Task<ActionResult> GetAllClaimAsync()

        [Test]
        public async Task TestGetAllClaimTypeAsync()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO
            {
                ClaimName = "Natural"
            };
            ClaimType claimEntity = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };
            mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);
            var result = await controller.CreateClaimAsync(claimTypeDTO);

            mapper.Setup(m => m.Map<ClaimTypeDTO>(claimEntity)).Returns(claimTypeDTO);
            var reponse = await controller.GetAllClaimAsync();
            Assert.IsNotNull(result);
            var resultObject = result as ObjectResult; // Use ObjectResult for BadRequest
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(StatusCodes.Status200OK, resultObject.StatusCode);
        }

        [Test]
        public async Task TestExceptionGetAllClaimType()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO
            {
                ClaimName = "Natural"
            };
            ClaimType claimEntity = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };


            mapper.Setup(m => m.Map<ClaimTypeDTO>(claimEntity)).Returns(claimTypeDTO);
            var reponse = await controller.GetAllClaimAsync();
            Assert.IsNotNull(reponse);
            var resultObject = reponse as ObjectResult; // Use ObjectResult for BadRequest
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(StatusCodes.Status400BadRequest, resultObject.StatusCode);
        }
    }
}