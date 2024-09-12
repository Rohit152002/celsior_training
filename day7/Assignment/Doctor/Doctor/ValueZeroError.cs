using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    internal class ValueZeroError:Exception
    {
        string message;
        public ValueZeroError(string message) {
            message = message;
        }
        public override string Message => message;
    }
}
