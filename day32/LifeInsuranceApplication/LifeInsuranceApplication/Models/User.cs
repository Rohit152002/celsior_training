
    using System.ComponentModel.DataAnnotations;

namespace LifeInsuranceApplication.Models
{
    public enum Roles
    {
        Admin,
        Supplier,
        Customer,
        Employee
    }
    public class User
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public byte[] Password { get; set; }
        public byte[] HashKey { get; set; }
        public Roles Role { get; set; }
    

    }
}

