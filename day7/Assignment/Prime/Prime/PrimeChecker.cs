using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    internal class PrimeChecker
    {
        List<int> primeNumbers = new List<int>();

        public bool IsPrime(int num)
        {
            if (num < 2) return false;

            for(int i=2;i<=Math.Sqrt(num);i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public void TakeInput()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter a number (enter 0 to stop):");
                    int num = Convert.ToInt32(Console.ReadLine());

                    if (num == 0)
                        break;

                    if (IsPrime(num))
                    {
                        primeNumbers.Add(num);
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter an integer");
                }
                
            }
        }

        public void PrintPrimes()
        {
            if(primeNumbers.Count> 0)
            {
                Console.WriteLine("Prime numbers entered " + string.Join(", ",primeNumbers));
            }
            else
            {
                Console.WriteLine("No prime numbers were entered");
            }
        }
    }
}
