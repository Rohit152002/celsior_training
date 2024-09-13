namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeePromotion employees = new EmployeePromotion();
            employees.InputEmployeeNameFromConsole();
            Console.WriteLine("----------------------------");
            employees.ListOfEmployeeName();
            Console.WriteLine("----------------------------");

            Console.WriteLine("Please enter the name of the employee to check promotion position");
            string inputName = Console.ReadLine();

            int position = employees.FindPromotionPostion(inputName);
            if (position == -1)
            {
                Console.WriteLine($"There is no Employee with this {inputName} name");
                return;
            }
            Console.WriteLine($" \"{inputName}\" is the position {position} for promotion ");

            Console.WriteLine("----------------------------");

            employees.CapacityOfList();

            Console.WriteLine("Promoted employee List");
            employees.Sorting();

        }

    }
}
