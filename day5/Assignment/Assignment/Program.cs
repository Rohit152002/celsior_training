﻿namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Average 
            int n;
            double average;
            Console.WriteLine("Enter the no. of elements : ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter {n} number ");
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            Average user1 = new Average(numbers);
            average = user1.findAverage();
            Console.WriteLine($"Average no. is {average} ");

            //prime
            int min, max;
            Console.WriteLine("Enter a min number ");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a max number: ");
            max = Convert.ToInt32(Console.ReadLine());

            Prime num1 = new Prime(min, max);
            int[] list = num1.listOfPrimeNumber();

            Console.WriteLine("List of Prime Number are ");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ,");
            }

            //Divisible by three
            List<int> inputList= new List<int>();
            Console.WriteLine("Enter a list of number until -1 ");
            int input;
            while((input=Convert.ToInt32(Console.ReadLine()))!=-1)
            {
                inputList.Add(input);
            }

            DivisibleByThree userinput = new DivisibleByThree(inputList);
            List<int> result = userinput.listOfDivisibleNumberByThree();
            Console.WriteLine("List of Divisible by Three is ");
            foreach (var item in result)
            {
                Console.Write(item + ", ");
            }

            //number to word 



        }
    }
}