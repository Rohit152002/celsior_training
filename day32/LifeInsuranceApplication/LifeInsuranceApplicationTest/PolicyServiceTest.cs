using AutoMapper;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
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
    internal class PolicyServiceTest
    {
        DbContextOptions options;
        InsuranceContext context;

        PolicyService service;
        Mock<ILogger<PolicyRepository>> logger;
        PolicyRepository repository;
        Mock<IMapper> mapper;
       

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
                .UseInMemoryDatabase("testadd" + Guid.NewGuid())
                .Options;
            context = new InsuranceContext(options);
            mapper = new Mock<IMapper>();
            logger = new Mock<ILogger<PolicyRepository>>();
            //repository = new Mock<IRepository<int, Claim>>();
            repository = new PolicyRepository(context, logger.Object);

        }

        //public async Task<int> CreateNewPolicy(PolicyDTO policy)
        [Test]
        public async Task CreateNewPolicyTest()
        {
            PolicyDTO policyDTO = new PolicyDTO
            {
                PolicyNumber = "FLDSKJ223"
            };
            Policy policy = new Policy
            {
                PolicyNumber = "FLDSKJ223"
            };
            mapper.Setup(m => m.Map<Policy>(policyDTO)).Returns(policy);

            service = new PolicyService(repository, mapper.Object);
            int i = await service.CreateNewPolicy(policyDTO);
            Assert.AreEqual(1, i);
        }
        [Test]
        public async Task ExceptionTest()
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

            service = new PolicyService(repository, mapper.Object);
            Assert.ThrowsAsync<Exception>(async()=> await service.CreateNewPolicy(policyDTO));
        }
        //     public async Task<PolicyDTO> DeletePolicy(int policyId)
        [Test]
        public async Task TestDeletePolicy()
        {
            PolicyDTO policyDTO = new PolicyDTO
            {
                PolicyNumber = "FDLJFD97"
            };
            Policy policy = new Policy
            {
                PolicyNumber = "FDLJFD97"
            };
            mapper.Setup(m => m.Map<Policy>(policyDTO)).Returns(policy);

            service = new PolicyService(repository, mapper.Object);
            int i = await service.CreateNewPolicy(policyDTO);

            mapper.Setup(m => m.Map<PolicyDTO>(policy)).Returns(policyDTO);
            service = new PolicyService(repository, mapper.Object);

            PolicyDTO deleteDTO= await service.DeletePolicy(i);

            Assert.NotNull(deleteDTO);

        }

        [Test]
        public async Task ExceptionTestDeletePolicy()
        {
            service = new PolicyService(repository, mapper.Object);
            Assert.ThrowsAsync<Exception>(async () => await service.DeletePolicy(1));
        }
        //public async Task<IEnumerable<PolicyDTO>> GetAllPolicies()
        [Test]
        public async Task TestGetAllPolicies()
        {
            PolicyDTO policyDTO = new PolicyDTO
            {
                PolicyNumber = "FDLJFD97"
            };
            Policy policy = new Policy
            {
                PolicyNumber = "FDLJFD97"
            };
            mapper.Setup(m => m.Map<Policy>(policyDTO)).Returns(policy);

            service = new PolicyService(repository, mapper.Object);
            int i = await service.CreateNewPolicy(policyDTO);

            mapper.Setup(m => m.Map<PolicyDTO>(policy)).Returns(policyDTO);
            service = new PolicyService(repository, mapper.Object);
            var policies= await service.GetAllPolicies();
            Assert.NotNull(policies);

        }
        [Test]
        public async Task TestExceptionGetAllPolicies()
        {
            Assert.ThrowsAsync<Exception>(async()=>await service.GetAllPolicies());
        }
        //public async Task<PolicyDTO> GetPolicyById(int policyId)
        [Test]
        public async Task TestGetPolicyById()
        {
            PolicyDTO policyDTO = new PolicyDTO
            {
                
                PolicyNumber = "FDLJFD97"
            };
            Policy policy = new Policy
            {
                PolicyNumber = "FDLJFD97"
            };
            mapper.Setup(m => m.Map<Policy>(policyDTO)).Returns(policy);

            service = new PolicyService(repository, mapper.Object);
            int i = await service.CreateNewPolicy(policyDTO);
            mapper.Setup(m => m.Map<PolicyDTO>(policy)).Returns(policyDTO);
            service = new PolicyService(repository, mapper.Object);
            var policies = await service.GetPolicyById(i);
            Assert.NotNull(policies);
        }
        [Test]
        public async Task TestGetPolicyByIdException()
        {
            service = new PolicyService(repository, mapper.Object);
            Assert.ThrowsAsync<Exception>(async () => await service.GetPolicyById(1));

        }
}
}
