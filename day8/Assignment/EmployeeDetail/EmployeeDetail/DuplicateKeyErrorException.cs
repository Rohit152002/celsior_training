using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetail
{
    internal class DuplicateKeyErrorException:Exception
    {
        string message;
        public DuplicateKeyErrorException(string message) : base(message) { }
    }
}
