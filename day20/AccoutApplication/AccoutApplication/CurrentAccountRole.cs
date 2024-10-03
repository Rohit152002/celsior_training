using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutApplication
{
    internal class CurrentAccountRole:Account
    {
        public CurrentAccountRole(string accountNumber, string accountHolderName, double initialBalance)
        : base(accountNumber, accountHolderName, initialBalance)
        {
        }
    }
}
