using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Issue
{
    internal class Employee
    {
        //Employee employee1 = new Employee(101, "John", "Manager", 50000, new DateTime(1980, 1, 1), 10);
        public int Id;
        public string Name;
        public string Designation;
        public double Salary;
        public int TotalLeave;
        public DateTime DateOfBirth;

        public Employee(int id, string firstName, string lastName, double role, DateTime salary, int dob)
        {
            this.Id= id;
            this.Name = firstName;
            this.Designation = lastName;
            this.Salary = role;
            this.DateOfBirth = salary;
            this.TotalLeave = dob;
        }
        public Employee()
        {
            
        }
        public void show()
        {
            Console.WriteLine(Id+Name);
        }
        

    }
}
