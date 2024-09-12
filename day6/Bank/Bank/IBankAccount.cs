using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal interface IBankAccount
    {
        void Deposit(double amount);
        void WithDraw(double amount);
        double getBalance();
        bool hasSufficientBalance(double amount);
    }
}
