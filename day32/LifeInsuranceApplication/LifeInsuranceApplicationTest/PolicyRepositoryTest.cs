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
    internal class PolicyRepositoryTest
    {
        DbContextOptions options;
        InsuranceContext context;
        PolicyRepository repository;
        Mock<ILogger<PolicyRepository>> logger;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
                .UseInMemoryDatabase("testadd" + Guid.NewGuid())
                .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<PolicyRepository>>();
            repository = new PolicyRepository(context, logger.Object);

        }
        //[TearDown]
        //public void TearDown()
        //{
        //    context.Dispose();
        //}

        [Test]
       public async Task TestAddPolicyType()
        {
            Policy policy = new Policy
            {
                Id = 1,
                PolicyNumber = "FALDKJF213",
                PolicyDescription="General Policy"

            };

            var policyAdded = await repository.Create(policy);
            Assert.AreEqual(policy.Id, policyAdded);
        }

        [Test]
        public async Task TestAddExceptionTest()
        {
            Policy policy = new Policy
            {
                Id = 1,
                PolicyNumber = null,
                PolicyDescription = "General Policy"
            };
            Assert.ThrowsAsync<Exception>(async () => await repository.Create(policy));
        }

        [Test]
        public async Task DeleteTest()
        {
            Policy policy = new Policy
            {
                Id = 1,
                PolicyNumber = "FALDKJF213",
                PolicyDescription = "General Policy"
            };

            var policyAdded = await repository.Create(policy);

            var deletedClaim = await repository.Delete(policyAdded);
            Assert.AreEqual(deletedClaim.Id, policy.Id);
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
            Policy policy = new Policy
            {
                Id = 1,
                PolicyNumber = "FALDKJF213",
                PolicyDescription = "General Policy"
            };

         
            await repository.Create(policy);
            
            var policies = await repository.GetAll();
            Assert.NotNull(policies);
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

            Policy policy = new Policy
            {
                Id = 1,
                PolicyNumber = "FALDKJF213",
                PolicyDescription = "General Policy"
            };


            await repository.Create(policy);

            Policy updatepolicy = new Policy
            {
                PolicyNumber = "FALDKJF113",
                PolicyDescription = "General Policy"
            };


            var update = await repository.Update(1, updatepolicy);
            Assert.AreEqual(update.PolicyNumber, updatepolicy.PolicyNumber);

        }
        [Test]
        public async Task UpdateClaimTypeExceptionTest()
        {
            Assert.ThrowsAsync<Exception>(async () => await repository.Update(1, new Policy { PolicyNumber = "FAD2342SD" }));

        }


    }
}