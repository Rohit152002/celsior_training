namespace lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number,k;
            Console.WriteLine("Enter a number of elements : ");
            number=Convert.ToInt32(Console.ReadLine());
            int[] array=new int[number];

            Console.WriteLine($"Enter a {number} number : ");
            for (int i = 0; i < number; i++)
            {
                int input=Convert.ToInt32(Console.ReadLine());
                array[i] = input;
            }

            Solution sln1= new Solution(array);
            int[] result=sln1.arrayNumber;
            foreach (int i in result)
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine("\nInput a Rotate Number");
            k =Convert.ToInt32( Console.ReadLine());

          for ( int i=0;i<k;i++)
            {
                Console.WriteLine($"Rotate  {i+1} \n");
                sln1.rotate();
            }

            
        }
    }
}
