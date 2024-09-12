namespace CardValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the card number to validate : ");
                string cardNumber=Console.ReadLine();

                if(string.IsNullOrEmpty(cardNumber))
                {
                    throw new InvalidCardNumberExecption("Card number cannot be null or empty");
                }

                ICardValidator card = new CardValidator(cardNumber);

                bool isValid= card.IsValid();

                if(isValid )
                {
                    Console.WriteLine("The card number is valid");
                }
                else
                {
                    Console.WriteLine("The card number is invalid");
                }
            }
            catch (InvalidCardNumberExecption e)
            {
                Console.WriteLine($"Error : {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error {e}");
            }
        }
    }
}
