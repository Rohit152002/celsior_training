using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutApplication
{
    internal class CurrentAccount : Operation
    {
        static List<Account> currentAccount = new List<Account>() {
            new Account() { Id=1,Name="Disha",AccountNumber=923492378423,CurrentBalance=400},
        new Account() {Id=2,Name="Sudarshan",AccountNumber=982409987243,CurrentBalance=1000} };

        public override void CreateAccount()
        {
            Account account = new Account();
            Console.Write("Enter your Name :- ");
            string name = Console.ReadLine();
            account.Name = name;
            account.CurrentBalance = 0;
            currentAccount.Add(account);
            Console.WriteLine(account);
            Console.WriteLine("Accounts have been created");
        }
        public override void CreditMoney(float money, int id)
        {
            Account account = currentAccount.FirstOrDefault(a => a.Id == id);
            if (account == null) { throw new Exception("No account found"); }
         
            account.CurrentBalance += money;
            Console.WriteLine($"{money} has been credited");
        }

        public override void ShowBalance(int id)
        {
            Account account = currentAccount.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                throw new Exception("No account found");
            }
            Console.WriteLine($"Available balance : {account.CurrentBalance}");

        }

        public override void WithdrawMoney(float money, int id)
        {
            Account account = currentAccount.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                throw new Exception("No account found");
            }
            if (account.CurrentBalance < money)
            {
                throw new Exception("Insufficent amount to be withdraw");
            }

            account.CurrentBalance -= money;
            Console.WriteLine($"{money} has been withdraw");
        }
    }
}
