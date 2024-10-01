using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutApplication
{
    internal  class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public double InitialBalance { get; set; }
        static int i = 3;

        protected Account(string accountNumber, string accountHolderName, double initialBalance)
        {
            Id= i;
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            InitialBalance = initialBalance;
            i++;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {AccountHolderName}\nAccountNumber={AccountNumber}\nCurrent Balance={InitialBalance}";
        }
    }
}
