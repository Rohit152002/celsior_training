using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Solution
    {
        private int binaryNumber;

        private int input;
        public Solution(int N ) {
            this.input = N;
            this.binaryNumber = ConvertToBinary(N);
        }
        public int ConvertToBinary(int N)
        {
            int binaryNumber = 0;
            int place = 1;
            while (N > 0)
            {
                binaryNumber += (N % 2) * place;
                place *= 10;
                N /= 2;
            }
            Console.WriteLine(binaryNumber);
  
            return (binaryNumber);
        }
      

        public int binaryGap()
        {
            int count = 0;
            int max=0;
  
            string binaryString = Convert.ToString(this.binaryNumber);
            for (int i = 0; i < binaryString.Length - 1; i++)
            {
                if (binaryString[i] == '0' )
                {
                    count++;
              
                 
                }
               else if (binaryString[i] == '1')
                {
                  
                    if ( count> max)
                    {
                        max = count;
                    }
                    count = 0;
                }
            }
            return max;
        }
    }
}


//int gapMax = 0;
//int zeroCount = 0;
//string nBinary = Convert.ToString(N, 2);
//for (int i = 0; i < nBinary.Length; i++)
//{
//    if (nBinary[i] == '0')
//    {
//        zeroCount++;
//    }
//    else
//    {
//        if (zeroCount > gapMax)
//        {
//            gapMax = zeroCount;
//        }
//        zeroCount = 0;
//    }
//}
//return gapMax;