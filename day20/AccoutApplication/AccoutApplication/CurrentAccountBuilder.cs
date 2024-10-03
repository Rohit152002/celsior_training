using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutApplication
{
    internal class CurrentAccountBuilder : AccountBuilder
    {
        private string _accountNumber;
        private string _accountHolderName;
        private double _initialBalance;
        public Account Build()
        {
            return new CurrentAccount(_accountNumber, _accountHolderName, _initialBalance);
        }

        public AccountBuilder WithAccountNumber(string accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public AccountBuilder WithAccountHolderName(string accountHolderName)
        {
            _accountHolderName = accountHolderName;
            return this;
        }

        public AccountBuilder WithInitialBalance(double initialBalance)
        {
            _initialBalance = initialBalance;
            return this;
        }

     
    }
}
