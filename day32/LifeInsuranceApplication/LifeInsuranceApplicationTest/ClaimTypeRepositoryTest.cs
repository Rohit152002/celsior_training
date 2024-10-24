using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;
using Microsoft.Extensions.Logging;
using System.Text;
using Moq;
using LifeInsuranceApplication.Models;

namespace LifeInsuranceApplicationTest
{
    internal class ClaimTypeRepositoryTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimTypeRepository repository;
        Mock<ILogger<ClaimTypeRepository>> logger;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
                .UseInMemoryDatabase("testadd" + Guid.NewGuid())
                .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimTypeRepository>>();
            repository = new ClaimTypeRepository(context, logger.Object);

        }
        //[TearDown]
        //public void TearDown()
        //{
        //    context.Dispose();
        //}

        [Test]
        public async Task TestAddClaimType()
        {
            ClaimType newClaimType = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };

            var addedClaim = await repository.Create(newClaimType);
            Assert.AreEqual(newClaimType.Id, addedClaim);
        }

        [Test]
        public async Task TestAddExceptionTest()
        {
            ClaimType claimType = new ClaimType
            {
                Id = 1,
                ClaimName = null
            };
            Assert.ThrowsAsync<Exception>(async () => await repository.Create(claimType));
        }

        [Test]
        public async Task DeleteTest()
        {
            ClaimType newClaimType = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };

            var addedClaim = await repository.Create(newClaimType);

            var deletedClaim = await repository.Delete(addedClaim);
            Assert.AreEqual(deletedClaim.Id, newClaimType.Id);
        }

        [Test]
        public async Task DeleteExceptionDelete()
        {
            Assert.ThrowsAsync<Exception>(async () => await repository.Delete(1));
        }

        //        public async Task<IEnumerable<ClaimType>> GetAll()
        [Test]
        public async Task GetAll()
        {
            ClaimType newClaimType = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };
            ClaimType newClaimType2 = new ClaimType
            {
                Id = 2,
                ClaimName = "Normal"
            };

            await repository.Create(newClaimType);
            await repository.Create(newClaimType2);
            var claims = await repository.GetAll();
            Assert.NotNull(claims);
        }


        [Test]
        public async Task GetAllExceptionTest()
        {
            Assert.ThrowsAsync<Exception>(async () => await repository.GetAll());
        }

        //        public async Task<ClaimType> Update(int key, ClaimType entity)

        [Test]
        public async Task UpdateClaimTypeTest()
        {
            ClaimType claimType = new ClaimType
            {
                Id = 1,
                ClaimName = "Accident"
            };
            await repository.Create(claimType);

            ClaimType update = new ClaimType
            { ClaimName="Natural"};


            var updateClaims = await repository.Update(1, update);
            Assert.AreEqual(updateClaims.ClaimName, claimType.ClaimName);

        }
        [Test]
        public async Task UpdateClaimTypeExceptionTest()
        {
            Assert.ThrowsAsync<Exception>(async () => await repository.Update(1, new ClaimType { ClaimName="Accident" }));

        }


    }
}