using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_part2
{
    internal class Solution
    {
        public int[] array;
        public Solution(int[] A)
        {
            this.array = A;
        }
        
        public int findOddOccurrenceInArray()
        {
            int result = 0;

            foreach (int number in this.array)
            {
                result ^= number; 
            }

            return result;
        }
    }
}
