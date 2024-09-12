namespace Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrimeChecker primeChecker = new PrimeChecker();

            primeChecker.TakeInput();
            primeChecker.PrintPrimes();
        }
    }
}
