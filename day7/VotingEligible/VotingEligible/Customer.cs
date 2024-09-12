using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingEligible
{
    public class Customer
    {
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public char gender { get; set; }

        public void takeInputUserFromConsole()
        {
            Console.WriteLine("Enter your details : ");
            Console.Write("Name");
            name = Convert.ToString(Console.ReadLine());
            Console.Write("Date of Birth (YYYY,MM,DD)");
            dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Gender");
            gender=Convert.ToChar(Console.ReadLine());
        }
    }
}
