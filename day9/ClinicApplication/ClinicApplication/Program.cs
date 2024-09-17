namespace ClinicApplication
{
    internal class Program
    {
        void PrintMenu()
        {
            Console.WriteLine("Clinic Management System ");
            Console.WriteLine("Enter a choice ( 0 to exit): ");
            Console.WriteLine("1. Patient");
            Console.WriteLine("2. Doctor");
        }

        void RegisterOrLoginInteraction()
        {
            Console.WriteLine("1. Register ");
            Console.WriteLine("2. Login");
        }

        void Doctor()
        {

        }

        void Patient()
        {

        }

        void FirstUserInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                choice=Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        Doctor();
                        break;
                    case 2:
                        Patient();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }

            }
            while (true);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.FirstUserInteraction();
        }
    }
}
