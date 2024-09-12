using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingEligible
{
    internal class InvalidDateException: Exception
    {
        string message;
        public InvalidDateException()
        {
            message = "The input date was greater than the current date. Please try again";
        }

        public override string Message => message;
    }
}
