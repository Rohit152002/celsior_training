namespace AccoutApplication
{
    internal class Program
    {
        CurrentAccount currentAccount = new CurrentAccount();
        SavingAccount savingAccount = new SavingAccount();

        void CommonMenu()
        {
            Console.WriteLine("Please enter a choice:- ");
            Console.WriteLine("1. Saving Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Back");
        }
        void UserInteraction()
        {

            Console.WriteLine("Welcome to Services");
            int choice = -1;
            do
            {

                CommonMenu();

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SavingServices();
                        break;
                    case 2:
                        CurrentServices();
                        break;
                    case 3:
                        FirstMenu();
                        break;

                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            } while (choice != 0);

        }
        void CreateAccount()
        {
            Console.WriteLine("Welcome, Please create an account!!");
            int choice = -1;
            do
            {
                CommonMenu();

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        savingAccount.CreateAccount();
                        SavingServices();
                        break;
                    case 2:
                        currentAccount.CreateAccount();
                        CurrentServices();
                        
                        break;
                    case 3:
                        FirstMenu();
                        break;

                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            } while (choice != 0);
        }
        void FirstMenu()
        {
            Console.WriteLine("Welcome to Banking Application");
            int choice = -1;
            do
            {

                Console.WriteLine("Please enter a choice:- ");
                Console.WriteLine("1. Already have account");
                Console.WriteLine("2. Create Account");
                Console.WriteLine("3. Back");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UserInteraction();
                        break;
                    case 2:
                        CreateAccount();
                        break;
                    case 3:
                        FirstMenu();
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            } while (choice != 0);
        }

        void AccountMenu()
        {
            Console.WriteLine("Please enter a choice:- ");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Back");

        }



        void SavingServices()
        {
            Console.WriteLine("Welcome to Saving services");
            int choice = -1;
            Console.Write("Enter an user id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {

                do
                {

                    AccountMenu();
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter amount:- ");
                            float creditMoney = float.Parse(Console.ReadLine());
                            savingAccount.CreditMoney(creditMoney, id);
                            break;
                        case 2:
                            Console.Write("Enter amount:- ");
                            float withdrawMoney = float.Parse(Console.ReadLine());
                            savingAccount.WithdrawMoney(withdrawMoney, id);
                            break;
                        case 3:
                            savingAccount.ShowBalance(id);
                            break;
                        case 4:
                            UserInteraction();
                            break;
                        default:
                            Console.WriteLine("Enter a valid option");
                            break;
                    }

                } while (choice != 0);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
        void CurrentServices()
        {
            Console.WriteLine("Welcome to Current services");

            int choice = -1;
            Console.Write("Enter an user id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {

                do
                {
                    AccountMenu();
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter amount:- ");
                            float money = float.Parse(Console.ReadLine());
                            currentAccount.CreditMoney(money, id);
                            break;
                        case 2:
                            Console.Write("Enter amount:- ");
                            float withdraw_money = float.Parse(Console.ReadLine());
                            currentAccount.WithdrawMoney(withdraw_money, id);
                            break;
                        case 3:
                            currentAccount.ShowBalance(id);
                            break;
                        case 4:
                            UserInteraction();
                            break;
                        default:
                            Console.WriteLine("Enter a valid option");
                            break;
                    }

                } while (choice != 0);

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }



        static void Main(string[] args)
        {

            Program program = new Program();
            program.FirstMenu();
        }
    }
}
