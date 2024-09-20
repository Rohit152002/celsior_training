using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class EmployeePromotion
    {
        List<string> EmployeeNames = new List<string>();
        public EmployeePromotion()
        { }

        public void InputEmployeeNameFromConsole()
        {
            Console.WriteLine("Please enter the employee names in the order of their eligibility for\r\npromotion(Please enter blank to stop)\n");
            string? input;
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        break;
                    }
                    EmployeeNames.Add(input);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Error : {e}");
                }
            }
        }

        public void ListOfEmployeeName()
        {
            if (EmployeeNames.Count == 0)
            {
                Console.WriteLine("Please enter employee name");
                Environment.Exit(0);
                return;
            }
            foreach (string name in EmployeeNames)
            {
                Console.WriteLine(name);
            }
        }

        public int FindPromotionPostion(string inputName)
        {
            int index = EmployeeNames.IndexOf(inputName);
            return index;
        }

        public void CapacityOfList()
        {
            Console.WriteLine($"The current size of the collection is {EmployeeNames.Capacity}");
            EmployeeNames.TrimExcess();
            Console.WriteLine($"The size after removing the extra space is {EmployeeNames.Capacity}");
        }

        public void Sorting()
        {
            EmployeeNames.Sort();
            foreach (var name in EmployeeNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
