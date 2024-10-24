using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
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
    internal class ClaimRepositoryTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimRepository repository;
        Mock<ILogger<ClaimRepository>> logger;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
                .UseInMemoryDatabase("testadd" + Guid.NewGuid())
                .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimRepository>>();
            repository = new ClaimRepository(context, logger.Object);

        }

        [Test]
        public async Task TestAddClaim()
        {
            Claim claim = new Claim
            {
                PolicyId = 1,
                ClaimTypeId =1,
                DateOfIncident = DateTime.Now,
                ClaimantName = "rohit",
                ClaimantPhone = "1287631927",
                ClaimantEmail = "rohit@gmail.com",
                SettleForm = "flkdf.jpg",
                DeathCertificateForm = "flkdf.jpg",
                PolicyCertificateForm = "flkdf.jpg",
                Photo = "flkdf.jpg",
                AddressProof = "flkdf.jpg",
                CancelCheck = "flkdf.jpg",
                Other = "flkdf.jpg",
            };

            var claimadded = await repository.Create(claim);
            Assert.AreEqual(claim.Id, claimadded);
        }

        [Test]
        public async Task TestAddExceptionTest()
        {
            Claim claim = new Claim
            {
                PolicyId = 1,
                ClaimTypeId = 1,
                DateOfIncident = DateTime.Now,
                ClaimantName = null,
                ClaimantPhone = null,
                ClaimantEmail = "rohit@gmail.com",
                SettleForm = "flkdf.jpg",
                DeathCertificateForm = "flkdf.jpg",
                PolicyCertificateForm = "flkdf.jpg",
                Photo = "flkdf.jpg",
                AddressProof = "flkdf.jpg",
                CancelCheck = "flkdf.jpg",
                Other = "flkdf.jpg",
            };
            Assert.ThrowsAsync<Exception>(async () => await repository.Create(claim));
        }

        [Test]
        public async Task DeleteTest()
        {
            Claim claim = new Claim
            {
                Id= 1,
                PolicyId = 1,
                ClaimTypeId = 1,
                DateOfIncident = DateTime.Now,
                ClaimantName = "rohit",
                ClaimantPhone = "1287631927",
                ClaimantEmail = "rohit@gmail.com",
                SettleForm = "flkdf.jpg",
                DeathCertificateForm = "flkdf.jpg",
                PolicyCertificateForm = "flkdf.jpg",
                Photo = "flkdf.jpg",
                AddressProof = "flkdf.jpg",
                CancelCheck = "flkdf.jpg",
                Other = "flkdf.jpg",
            };

            var claimadded = await repository.Create(claim);

            var deletedClaim = await repository.Delete(claimadded);
            Assert.AreEqual(deletedClaim.Id, 1);
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
            Claim claim = new Claim
            {
                Id = 1,
                PolicyId = 1,
                ClaimTypeId = 1,
                DateOfIncident = DateTime.Now,
                ClaimantName = "rohit",
                ClaimantPhone = "1287631927",
                ClaimantEmail = "rohit@gmail.com",
                SettleForm = "flkdf.jpg",
                DeathCertificateForm = "flkdf.jpg",
                PolicyCertificateForm = "flkdf.jpg",
                Photo = "flkdf.jpg",
                AddressProof = "flkdf.jpg",
                CancelCheck = "flkdf.jpg",
                Other = "flkdf.jpg",
            };

            var claimadded = await repository.Create(claim);

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

            Claim claim = new Claim
            {
                Id = 1,
                PolicyId = 1,
                ClaimTypeId = 1,
                DateOfIncident = DateTime.Now,
                ClaimantName = "rohit",
                ClaimantPhone = "1287631927",
                ClaimantEmail = "rohit@gmail.com",
                SettleForm = "flkdf.jpg",
                DeathCertificateForm = "flkdf.jpg",
                PolicyCertificateForm = "flkdf.jpg",
                Photo = "flkdf.jpg",
                AddressProof = "flkdf.jpg",
                CancelCheck = "flkdf.jpg",
                Other = "flkdf.jpg",
            };

            var claimadded = await repository.Create(claim);

            Claim updateclaim = new Claim
            {
                Id = 1,
                PolicyId = 1,
                ClaimTypeId = 1,
                DateOfIncident = DateTime.Now,
                ClaimantName = "johhny",
                ClaimantPhone = "1287631927",
                ClaimantEmail = "rohit@gmail.com",
                SettleForm = "flkdf.jpg",
                DeathCertificateForm = "flkdf.jpg",
                PolicyCertificateForm = "flkdf.jpg",
                Photo = "flkdf.jpg",
                AddressProof = "flkdf.jpg",
                CancelCheck = "flkdf.jpg",
                Other = "flkdf.jpg",
            };



            var update = await repository.Update(1, updateclaim);
            Assert.AreEqual(update.ClaimantName, updateclaim.ClaimantName);

        }
        [Test]
        public async Task UpdateClaimTypeExceptionTest()
        {
            Assert.ThrowsAsync<Exception>(async () => await repository.Update(1, new Claim { Other = "FAD2342SD" }));

        }

    }
}
