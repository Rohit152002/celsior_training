using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingEligible
{
    internal interface IValidation
    {
        public bool CheckEligiblity(DateTime dateOfBirth);
        public void PrintValidation();
    }
}
