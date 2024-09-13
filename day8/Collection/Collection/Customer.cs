using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    internal class Customer:IEquatable<Customer>,IComparable<Customer>
    {
        public string Name;
        public int Id;
        public Customer()
        {
            
        }
        public Customer(string name)
        {
            this.Name = name;
        }
        public void GetCustomerDetaislFromConsole()
        {
            Console.Write("Please enter your name : ");
            Name = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"Customer Name: {Name}";
        }

        public bool Equals(Customer? other)
        {
            Customer c1, c2;
            c1 = this;
            c2 = other;
            if ( c1.Name == c2.Name )
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Customer? other)
        {
            Console.WriteLine(this.Name.CompareTo(other.Name));
            return this.Name.CompareTo(other.Name);
        }
    }
}
