using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutApplication
{
    internal interface AccountBuilder
    {
        AccountBuilder WithAccountNumber(string accountNumber);
        AccountBuilder WithAccountHolderName(string accountHolderName);
        AccountBuilder WithInitialBalance(double initialBalance);
        Account Build();
    }
}
