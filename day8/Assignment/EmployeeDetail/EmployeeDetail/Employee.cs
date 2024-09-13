using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetail
{
    public class Employee:IComparable<Employee>    {
        int id, age;
        string name;
        double salary;
        public Employee()
        {
        }
        public Employee(int id, int age, string name, double salary)
        {
            this.id = id;
            this.age = age;
            this.name = name;
            this.salary = salary;
        }
        public void TakeEmployeeDetailsFromUser()
        {
            try
            {
                Console.Write("Please enter the employee ID ");
                id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter the employee name");
                name = Console.ReadLine();
                Console.Write("Please enter the employee age ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter the employee salary ");
                salary = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format Error : " + e);
                throw new FormatException();
            }

        }
        public override string ToString()
        {
            return "Employee ID : " + id + "\nName:" + name + "\nAge:" + age +
            "\nSalary: " + salary;
        }

        public int CompareTo(Employee? other)
        {
            return this.Salary.CompareTo(other.Salary);
        }
        public int Id
        {
            get => id; set => id = value;
        }
        public int Age
        {
            get => age; set => age = value;
        }
        public string Name
        {
            get => name; set => name = value;
        }
        public double Salary
        {
            get => salary; set => salary = value;
        }
    }


}
