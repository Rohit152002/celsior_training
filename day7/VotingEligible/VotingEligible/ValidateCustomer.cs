using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingEligible
{
    public class ValidateCustomer : IValidation
    {
        public Customer Customer { get; set; }

        public ValidateCustomer()
        {
            Customer = new Customer();
        }
        public bool CheckEligiblity(DateTime dateOfBirth)
        {
            DateTime CurrentYear = DateTime.Today;
            int age = CurrentYear.Year - dateOfBirth.Year;
            if(age<0)
            {
                throw new InvalidDateException();
            }
            if(age >18)
            {
                return true;
            }
            return false;
        }

        public void PrintValidation()
        {
            Customer.takeInputUserFromConsole();
            try
            {

            if (CheckEligiblity(Customer.dateOfBirth))
            {
                Console.WriteLine("Age is validated");
            }
            else
            {
                Console.WriteLine("Age is not validated ( Under age) ");
            }
            } catch(InvalidDateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
