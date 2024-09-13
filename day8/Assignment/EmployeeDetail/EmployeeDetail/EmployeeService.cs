using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetail
{
    internal class EmployeeService
    {
        public Employee FindEmployeeByID(int id, Dictionary<int, Employee> employees)
        {
            foreach (var index in employees.Keys)
            {
                if (id == employees[index].Id)
                {
                    return (employees[index]);
                }
            }
            return null;
        }

        public void SortedBySalaries(Dictionary<int, Employee> employees)
        {
            List<Employee> list = employees.Values.ToList();
            list.Sort();
            foreach (var employee in list)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine(employee);
                Console.WriteLine("--------------------------");
            }
        }

        public void PrintAllEmployees(Dictionary<int, Employee> employees)
        {
            if(employees.Count < 0)
            {
                Console.WriteLine("There is no Employee Add Some Employeee");
                return;
            }
            foreach (var employee in employees.Values)
            {
                Console.WriteLine("\n--------------------------");
                Console.WriteLine(employee);
                Console.WriteLine("--------------------------\n");

            }
        }



        public List<Employee> ListOfUserByName(Dictionary<int, Employee> employees, string inputname)
        {
            List<Employee> result = new List<Employee>();
            foreach (var employee in employees)
            {
                if (inputname == employee.Value.Name)
                {
                    Console.WriteLine("\n--------------------------");
                    Console.WriteLine(employee.Value);
                    Console.WriteLine("--------------------------\n");

                    result.Add(employee.Value);
      
                }
            }
            return result;
        }
        public void ListOfUserWhichAreElder(Dictionary<int, Employee> employees, int age)
        {
            foreach (var employee in employees)
            {
                if (age < employee.Value.Age)
                {
                    Console.WriteLine("\n--------------------------");
                    Console.WriteLine(employee.Value);
                    Console.WriteLine("--------------------------\n");
                }
            }
        }

      
        void ModifictionPrintMenu()
        {

            Console.WriteLine("Modification Menu:");
            Console.WriteLine("1. Modify Name");
            Console.WriteLine("2. Modify Age");
            Console.WriteLine("3. Modify Salary");
            Console.WriteLine("0. Exit Modification Menu");
            Console.Write("Enter your choice: ");
        }
        
        public void Modification(Dictionary <int,Employee> employees)
        {
            Console.WriteLine("Enter Employee ID to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = FindEmployeeByID(id, employees);
            int choice;
            do
            {
                ModifictionPrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new Name : - ");
                        employee.Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new Age : - ");
                        employee.Age = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Enter new Salary : - ");
                        employee.Salary = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }

            }
            while (choice!=0);

        }

        public void Deletion(Dictionary <int, Employee> employees)
        {
            Console.WriteLine("Enter Employee ID to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if(!employees.ContainsKey(id))
            {
                Console.WriteLine("Employee has not found by this " + id);
                return;
            }
            employees.Remove(id);
            Console.WriteLine("Employee has been deleted");
        }
        

    }
}
