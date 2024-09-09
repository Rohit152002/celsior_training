namespace Lesson1
{
    internal class Program
    {
        static int takeinputNumber()
        {
            Console.WriteLine("Enter a number : ");
            return Convert.ToInt32(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            int num1 = takeinputNumber();
            Solution sln1 = new Solution(num1);
            int binaryGap= sln1.binaryGap();
            Console.WriteLine($"binary Gap : {binaryGap}");
        }
    }
}
