namespace Bank
{
    internal class Program
    {
        void printMenu()
        {
            Console.WriteLine("Bank Management");
            Console.WriteLine("1 - Normal Account");
            Console.WriteLine("2 - NRI Account");
            Console.WriteLine("3 - Salary Account");
        }
        
        void accoutUserInteraction(string bankType)
        {
            Console.WriteLine($"Enter for {bankType} Account");
            Console.WriteLine("1 - deposit");
            Console.WriteLine("2- withdraw");
            Console.WriteLine("3 - balance");

        }

        void AccountOperations(IBankAccount account, string accountType)
        {
            var choice = 0;
            do
            {
                accoutUserInteraction(accountType);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the deposit amount:");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;
                    case 2:
                        Console.WriteLine("Enter the withdraw amount:");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        account.WithDraw(withdrawAmount);
                        break;
                    case 3:
                        Console.WriteLine($"Current Balance: {account.getBalance()}");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (choice != 0);
        }

        void normalAccount()
        {
            double initialBalance;
            Console.WriteLine("Enter the initial balance(min 5000) :- ");
            initialBalance=Convert.ToDouble(Console.ReadLine());
            if (initialBalance < 5000)
            {
                Console.WriteLine("Initial balance must be at least 5000.");
                return;
            }
            NormalAccount normal = new NormalAccount(initialBalance);
            AccountOperations(normal, "Normal");
        }

        void nriAccount()
        {
            double initialBalance;
            Console.WriteLine("Enter the initial balance(min 10000) :- ");
            initialBalance = Convert.ToDouble(Console.ReadLine());
            if (initialBalance < 10000)
            {
                Console.WriteLine("Initial balance must be at least 10000.");
                return;
            }
            NRIAccount nriAccount = new NRIAccount(initialBalance);
            AccountOperations(nriAccount, "NRI");

        }

        void salaryAccount()
        {
            double initialBalance;
            Console.WriteLine("Enter the initial balance(min 5000) :- ");
            initialBalance = Convert.ToDouble(Console.ReadLine());
            Salary salaryAccount = new Salary(initialBalance);
            AccountOperations(salaryAccount, "Salary");
        }
        void userInteraction()
        {
            var choice = 0;
            do
            {
                printMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        normalAccount();
                        break;
                    case 2:
                        nriAccount();
                        break;
                    case 3:
                        salaryAccount();
                        break;

                    default:
                        Console.WriteLine("Ïnvalid option");
                        break;
                }
            } while (choice != 0);
        }


        static void Main(string[] args)
        {
            Program program = new Program();
                      program.userInteraction();

           
                    }
    }
}
