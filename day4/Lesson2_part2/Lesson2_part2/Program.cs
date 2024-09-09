namespace Lesson2_part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k,result;
            Console.WriteLine("element no. ");
            k=Convert.ToInt32(Console.ReadLine());
            int[] inputArray = new int[k];
            for(int i=0;i<inputArray.Length;i++)
            {
                inputArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            Solution sln1 = new Solution(inputArray);
            result=sln1.findOddOccurrenceInArray();
            Console.WriteLine("Odd occurence is " + result);
        }
    }
}
