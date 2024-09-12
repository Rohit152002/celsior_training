using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal abstract class BankAccountBase:IBankAccount
    {
        double balance;
        double minBalance;
        double transactionCharge;

        public BankAccountBase(double balance, double minBalance, double transactionCharge)
        {
            this.balance = balance;
            this.minBalance = minBalance;
            this.transactionCharge = transactionCharge;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount - (amount * transactionCharge);
            }
        }

        public double getBalance()
        {
            return balance;
        }

        public bool hasSufficientBalance(double amount)
        {
            return (balance - amount >= minBalance);
        }

        public void WithDraw(double amount)
        {
            if (hasSufficientBalance(amount))
            {
                balance -= (amount + (amount * transactionCharge));
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
        }
    }
}
