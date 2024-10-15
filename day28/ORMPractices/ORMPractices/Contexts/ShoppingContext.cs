using Microsoft.EntityFrameworkCore;
using ORMPractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMPractices.Contexts
{
    public  class ShoppingContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=5CD413DKPB\\ROHITLAISHRAM;Integrated Security=true;Initial Catalog=EntityFramework15Oct;TrustServerCertificate=True");

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierProduct> SupplierProduct { get; set; }

    }
}
