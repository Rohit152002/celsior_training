using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public long phone { get; set; }

        static int count = 0;
        
        public Customer(string name, long phone) {
            this.id = count;
            this.name = name;
            this.phone = phone;
            count++; 
        }

    }
}
