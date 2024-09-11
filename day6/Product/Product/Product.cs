using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; } 
        public int quantity { get; set; }

        static int count = 0;

        public Product()
        {
            
            this.id = count;
            count++;
        }
        public Product(string name, int price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
