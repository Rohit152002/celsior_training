using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2
{
    internal class Solution
    {
        public int[] arrayNumber { get; set; }
        public Solution(int[] array)
        {
            this.arrayNumber = array;
        }

        public int[] show()
        {
          
            return this.arrayNumber;
        }

        public void rotate()
        {

            int lastNumber = this.arrayNumber[arrayNumber.Length - 1];
           for (int i=this.arrayNumber.Length-1;i>0;i--)
            { 
                    this.arrayNumber[i] = this.arrayNumber[i-1];          
            }
            this.arrayNumber[0] = lastNumber;
           foreach (int i in this.arrayNumber)
            {
                Console.Write(i+ ",");
            }
           Console.WriteLine("\n");
            
        }
    }
}
