using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Prime
    {
        public int min { get; set; }
        public int max { get; set; }
        public Prime(int min, int max) {
            this.min = min;
            this.max = max;
        }

       bool checkPrime(int n)
        {
            if (n == 0 || n == 1)
                return false;
            else
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                        return false;
                }
            }
            return true;
        }

        public int[] listOfPrimeNumber()
        {
            
            int count = 0;
            for (int i=min; i <= max; i++)
            {
                if (checkPrime(i))
                    count++;
             }

            int[] primes = new int[count];
            int index = 0;
            for(int i=min; i <= max;i++)
            {
                if(checkPrime(i))
                {
                    primes[index] = i;
                    index++;
                }
            }

            return primes;
            
        }
    }
}
