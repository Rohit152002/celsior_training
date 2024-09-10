using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_part2
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public Employee(int id, string name, string firstName, string lastName, string title)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
        }

        public void print()
        {
            Console.WriteLine(Id+Name+FirstName+LastName);
        }
    }
}
