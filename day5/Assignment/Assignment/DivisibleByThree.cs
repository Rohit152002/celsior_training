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
        public int[] list { get; set; }

        bool isDivisblebyThree(int n)
        {
            if (n % 3 == 0) return true;
            return false;
        }

        public DivisibleByThree(int[] list)
        {
            this.list = list;
        }

        public int[] listOfDivisibleNumberByThree()
        {
            int count = 0;

            for (int i=0; i<list.Length; i++)
            {
                if (isDivisblebyThree(i)) count++;
            }
            int[] listNumbers= new int[count];
            int index = 0;
            for (int i = 0; i < listNumbers.Length; i++)
            { 
                if (!isDivisblebyThree(list[i]))
                {
                    listNumbers[index] = list[i];
                    index++;
                }
            }
        return listNumbers;
        }

    }
}
