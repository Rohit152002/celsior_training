using System.Security.Cryptography;

namespace Overflow
{
    internal class Program
    {

        void UnderstandingLimits()
        {
            int num1 = int.MaxValue;
            Console.WriteLine($"The value of num1 is {num1}");
            checked
            {
                try
                {
                    num1++;
                    Console.WriteLine($"The value of num1 after incrementing is {num1}");
                }catch(OverflowException)
                {
                    Console.WriteLine("Overflow occured");
                }
            }
        }

        void UnderstandingErrorHandling()
        {
            int num1 = 0;
            Console.WriteLine("Enter ");
            while(int.TryParse( Console.ReadLine(), out num1)==false);
            {
                Console.WriteLine("Invalid entry for number. Try again");
            }
            Console.WriteLine($"The value you have entered is {num1}");
        }

        void UnderstandingThreading()
        {
            lock (this)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 5)
                    {
                        Thread.Sleep(5000);
                    }
                    Console.WriteLine($"{Thread.CurrentThread.Name} {i}");

                }
            }
        }

        void UnderstandingUsageOfWaitTime()
        {
            for (int i=10;i<101;i=i+10)
            {
                if(i==50)
                {
                    Thread.Sleep(5000);
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} {i}");
            }
        }
        static void Main(string[] args)
        {
           Program program = new Program();
            //program.UnderstandingLimits();
            //program.UnderstandingErrorHandling();
            Thread t1, t2;
            t1 = new Thread(program.UnderstandingThreading);
            t1.Name = "Thread 1";
            t2 = new Thread(program.UnderstandingUsageOfWaitTime);
            t2.Name = "Thread 2";
            t1.Start();
            t2.Start();

        }
    }
}
