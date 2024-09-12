using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class NormalAccount :BankAccountBase
    {
        public NormalAccount(double initialBalance) : base(initialBalance, 5000, 0.001) { }
    }
}
