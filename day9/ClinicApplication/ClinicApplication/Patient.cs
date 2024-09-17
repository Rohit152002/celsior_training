using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public double Phone { get; set; }

        public Patient()
        {
            
        }
        public Patient(string Name, DateTime DateOfBirth, string email, string passsword, string gender,double phone)
        {
            this.Name = Name;
            this.Email = email;
            this.DateOfBirth = DateOfBirth;
            this.Password = passsword;
            this.Gender = gender;
            this.Phone = phone;
        }
        public override string ToString()
        {
            return $"Patient Name: {Name},Date of Birth: {DateOfBirth.ToShortDateString()}, Gender: {Gender}, Email: {Email}, Phone: {Phone}";
        }
    }
}
