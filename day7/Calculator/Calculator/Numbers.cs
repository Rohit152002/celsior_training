using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Numbers
    {
        public double num1 { get; set; }
        public double num2 { get; set; }

        public void TakeNumbersFromConsole()
        {
            Console.WriteLine("Please enter the first no. : ");
            num1=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the second no. : ");
            num2=Convert.ToDouble(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"Number1 is  {num1} and Number2 is num{num2}";
        }
    }

}
