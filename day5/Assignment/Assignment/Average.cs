using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Average
    {
        public int[] numbers { get; set; }
        public Average(int[] numbers) {
            this.numbers = numbers;
        }

        public double findAverage()
        {
            double average;
            int sum=0;
            for (int i= 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            average = sum / numbers.Length;
            return average;
        }
    }
}
