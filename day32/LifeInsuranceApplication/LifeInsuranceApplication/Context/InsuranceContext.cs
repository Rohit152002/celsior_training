using LifeInsuranceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication.Context
{
    public class InsuranceContext:DbContext
    {
        public InsuranceContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<ClaimType> ClaimTypes{ get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<User> Users{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Claim>()
           .HasOne(c=>c.ClaimType)
           .WithMany(c=>c.Claims)
           .HasForeignKey(c=>c.ClaimTypeId)
           .HasConstraintName("FK_Claim_Type");

           modelBuilder.Entity<Claim>()
           .HasOne(c=>c.Policy)
           .WithMany(c=>c.Claims)
           .HasForeignKey(c=>c.PolicyId)
           .HasConstraintName("FK_Policy_Name");
        }
    }
}