using AutoMapper;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsuranceApplicationTest
{
    internal class ClaimTypeServiceTest
    {
        DbContextOptions options;
        InsuranceContext context;

        ClaimTypeService service;
        Mock<ILogger<ClaimTypeRepository>> logger;
        ClaimTypeRepository repository;
        Mock<IMapper> mapper;
       

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
                .UseInMemoryDatabase("testadd" + Guid.NewGuid())
                .Options;
            context = new InsuranceContext(options);
            mapper = new Mock<IMapper>();
            logger = new Mock<ILogger<ClaimTypeRepository>>();
            repository = new ClaimTypeRepository(context, logger.Object);
            service = new ClaimTypeService(repository,mapper.Object);

        }

        //        public async Task<int> CreateNewClaimType(ClaimTypeDTO claimType)
        [Test]
        public async Task CreateNewClaimTypeTest()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO { 
            ClaimName="Natural"
            };
            ClaimType claimEntity = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };
            mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);
            
            service = new ClaimTypeService(repository, mapper.Object);
            int i= await service.CreateNewClaimType(claimTypeDTO);
            Assert.AreEqual(1, i);

        }

        [Test]
        public async Task TestExceptionClaimType()
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
         
            Assert.ThrowsAsync<Exception>(async () => await service.CreateNewClaimType(claimTypeDTO));
        }
        //        public async Task<ClaimTypeDTO> DeleteClaimsType(int claimTypeId)
        [Test]
        public async Task TestDeleteClaims()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO
            {
                ClaimName = "Natural"
            };
            ClaimType claimEntity = new ClaimType
            {
             
                ClaimName = "Accident"
            };
            mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);

            service = new ClaimTypeService(repository, mapper.Object);
            int i = await service.CreateNewClaimType(claimTypeDTO);

            mapper.Setup(m => m.Map<ClaimTypeDTO>(claimEntity)).Returns(claimTypeDTO);

            service = new ClaimTypeService(repository, mapper.Object);
            ClaimTypeDTO delete= await service.DeleteClaimsType(i);
            Assert.NotNull(delete);
        }
        [Test]
        public async Task TestExceptionDeleteClaimsType()
        {
            service = new ClaimTypeService(repository, mapper.Object);
            Assert.ThrowsAsync<Exception>(async () => await service.DeleteClaimsType(1));
        }

        //        public async Task<IEnumerable<ClaimTypeDTO>> GetAllClaims()
        [Test]
        public async Task TestGetAllClaimsType()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO
            {
                ClaimName = "Accident"
            };
            ClaimType claimEntity = new ClaimType
            {
                Id=1,
                ClaimName = "Accident"
            };
            mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);
            IClaimTypeService service = new ClaimTypeService(repository, mapper.Object);
            int i = await service.CreateNewClaimType(claimTypeDTO);
            IEnumerable<ClaimTypeDTO> claims = await service.GetAllClaims();
            Assert.NotNull(claims);
        }

        [Test]
        public async Task TestExceptionGetAllClaimsType()
        {
            //mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);
            service = new ClaimTypeService(repository, mapper.Object);
            Assert.ThrowsAsync<Exception>(async () => await service.GetAllClaims());
        }
        //        public async Task<ClaimTypeDTO> GetClaimById(int claimTypeId)
        [Test]
        public async Task TestGetClaimById()
        {
            ClaimTypeDTO claimTypeDTO = new ClaimTypeDTO
            {
                ClaimName = "Accident"
            };
            
            ClaimType claimEntity = new ClaimType
            {
                ClaimName = "Accident"
            };
            mapper.Setup(m => m.Map<ClaimType>(claimTypeDTO)).Returns(claimEntity);
            service = new ClaimTypeService(repository, mapper.Object);
            int i = await service.CreateNewClaimType(claimTypeDTO);
            mapper.Setup(m => m.Map<ClaimTypeDTO>(claimEntity)).Returns(claimTypeDTO);
            ClaimTypeDTO getClaim = await service.GetClaimById(i);
            Assert.AreEqual(getClaim.ClaimName, claimTypeDTO.ClaimName);
        }

        [Test]
        public async Task TestExceptionGetClaimById()
        {
            Assert.ThrowsAsync<Exception>(async()=>await service.GetClaimById(0));
        }

    }
}
