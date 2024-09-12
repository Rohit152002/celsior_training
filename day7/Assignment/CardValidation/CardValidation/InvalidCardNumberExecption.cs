using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardValidation
{
    public class InvalidCardNumberExecption:Exception
    {
        public InvalidCardNumberExecption(string message):base(message) { }
    }
}
