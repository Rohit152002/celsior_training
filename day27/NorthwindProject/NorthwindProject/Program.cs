namespace NorthwindProject
{
    internal class Program
    {
        ShoppingServices shoppingServices = new ShoppingServices();

        void PrintMenu()
        {
            Console.WriteLine("Enter a choice : ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Registration");
            Console.WriteLine("0. Exit");
        }

        void UserInteraction()
        {
            int choice = -1;
            do
            {
                PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        shoppingServices.Login();
                        break;
                    case 2:
                        shoppingServices.Register();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }

            }
            while (choice != 0);
        }
        static void Main(string[] args)
        {
           Program program = new Program();
            program.UserInteraction();
        }
    }
}
