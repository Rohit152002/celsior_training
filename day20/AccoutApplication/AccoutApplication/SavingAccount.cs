using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutApplication
{
    internal class SavingAccount : Operation
    {
        static List<Account> savingsAccount= new List<Account>() {
            new Account() { Id=1,Name="Rohit",AccountNumber=91782923423,CurrentBalance=4000},
        new Account()             {Id=2,Name="Sudarshan",AccountNumber=982409987243,CurrentBalance=1000} };

        public override void CreateAccount()
        {
            Account account= new Account();
            Console.Write("Enter your Name :- ");
            string name= Console.ReadLine();
            account.CurrentBalance = 0;
            account.Name = name;
            savingsAccount.Add(account);
            Console.WriteLine(account);
            Console.WriteLine("Accounts have been created");
        }
        public override void CreditMoney(float money,int id)
        {
            Account account = savingsAccount.FirstOrDefault(a => a.Id == id);
            if (account == null) { throw new Exception("No account found"); }
            if (money > 100000)
                throw new Exception("Not allowed to credit more than 1 lakh in saving account ");
            account.CurrentBalance += money;
            Console.WriteLine($"{money} has been credited");
        }

        public override void ShowBalance(int id)
        {
            Account account = savingsAccount.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                throw new Exception("No account found");
            }
            Console.WriteLine($"Available balance : {account.CurrentBalance}");

        }

        public override void WithdrawMoney(float money, int id)
        {
            Account account = savingsAccount.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                throw new Exception("No account found");
            }
            if(account.CurrentBalance < money)
            {
                throw new Exception("Insufficent amount to be withdraw");
            }

            account.CurrentBalance -= money;
            Console.WriteLine($"{money} has been withdraw");
        }
    }
}
