namespace VotingEligible
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidateCustomer customer = new ValidateCustomer();
            customer.PrintValidation();
            try
            {
                Console.WriteLine("Please entera  numebr");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter another  numebr");
                int num2 = Convert.ToInt32(Console.ReadLine());
                int sum = num1 / num2;
                Console.WriteLine($"The sum of {num1} and {num2} is {sum}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
