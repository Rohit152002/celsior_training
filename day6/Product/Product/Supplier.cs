using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Supplier
    {
        public int id { get; set; }
        public string name { get; set; }
        static int count = 0;

              public Supplier(string name)
        {
            this.id = count;
            this.name= name;
            count++;
        }
    }
}
