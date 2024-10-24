
using AutoMapper;
using Castle.Core.Logging;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Controller;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace LifeInsuranceApplicationTest
{
    public class PolicyControllerTest
    {
        DbContextOptions options;
        InsuranceContext context;
        PolicyRepository repository;
        PolicyService service;
        PolicyController controller;
        Mock<ILogger<PolicyRepository>> logger;
        Mock<IMapper> mapper;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
            .UseInMemoryDatabase("testAdd" + Guid.NewGuid())
            .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<PolicyRepository>>();
            mapper = new Mock<IMapper>();
            repository = new PolicyRepository(context, logger.Object);
            service = new PolicyService(repository, mapper.Object);
            controller = new PolicyController(service);
        }

        //        public async Task<IActionResult> CreatePolicyAsync(PolicyDTO policyDTO)
        [Test]
        public async Task TestCreatePolicy()
        {
            PolicyDTO policyDTO = new PolicyDTO
            {
                PolicyNumber = "FLDSKJ223"
            };
            Policy policy = new Policy
            {
                PolicyNumber = "FLDSKJ223"
            };

            // service = new PolicyService(repository, mapper.Object);
            mapper.Setup(m => m.Map<Policy>(policyDTO)).Returns(policy);
            var result = await controller.CreatePolicyAsync(policyDTO);
            Assert.IsNotNull(result);
           
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
        [Test]
        public async Task TestExceptionCreatePolicy()
        {
            PolicyDTO policyDTO = new PolicyDTO
            {
                PolicyNumber = null
            };
            Policy policy = new Policy
            {
                PolicyNumber = null
            };
            mapper.Setup(m => m.Map<Policy>(policyDTO)).Returns(policy);

              var result = await controller.CreatePolicyAsync(policyDTO);
            Assert.IsNotNull(result);
           
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(500, resultObject.StatusCode);
        }
        
        //        public async Task<IActionResult> GetAllPolicyAsync()

        [Test]
        public async Task TestGetAllPolicyAsync()
        {
             PolicyDTO policyDTO = new PolicyDTO
            {
                PolicyNumber = "ALSDKFJ23"
            };
            Policy policy = new Policy
            {
                PolicyNumber = "ALSDKFJ23"
            };
            mapper.Setup(m => m.Map<Policy>(policyDTO)).Returns(policy);

              var result = await controller.CreatePolicyAsync(policyDTO);
              mapper.Setup(m => m.Map<PolicyDTO>(policy)).Returns(policyDTO);
              var reponse = await controller.GetAllPolicyAsync();
                Assert.IsNotNull(reponse);
           
            var resultObject = reponse as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
        public async Task TestGetAllPolicyException()
        {
               PolicyDTO policyDTO = new PolicyDTO
            {
                PolicyNumber = "ALSDKFJ23"
            };
            Policy policy = new Policy
            {
                PolicyNumber = "ALSDKFJ23"
            };
            
            mapper.Setup(m => m.Map<PolicyDTO>(policy)).Returns(policyDTO);
              var reponse = await controller.GetAllPolicyAsync();
                Assert.IsNotNull(reponse);
           
            var resultObject = reponse as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }

        

    }
}