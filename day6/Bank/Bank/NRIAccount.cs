using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class NRIAccount:BankAccountBase
    {
        public NRIAccount(double initialBalance) : base(initialBalance, 10000, 0.002) { }
    }
}
