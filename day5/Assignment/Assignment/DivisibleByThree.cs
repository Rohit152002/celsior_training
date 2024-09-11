using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class DivisibleByThree
    {
        public List<int> list { get; set; }

        bool isDivisblebyThree(int n)
        {
            if (n % 3 == 0) return true;
            return false;
        }

        public DivisibleByThree(List<int> list)
        {
            this.list = list;
        }

        public List<int> listOfDivisibleNumberByThree()
        {
            List<int> result = new List<int>();
            foreach (var number in list)
            {
                if (isDivisblebyThree(number))
                {
                    result.Add(number);
                }
            }
            return result;
        }
    }
}
