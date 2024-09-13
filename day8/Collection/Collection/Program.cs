using System.Collections;

namespace Collection
{
    internal class Program
    {
      
        void UnderstandingCollection()
        {
            ArrayList numbers = new ArrayList();
            numbers.Add(100);
            numbers.Add(234);
            numbers.Add(new Random().Next(100, 200));
            numbers.Add(new Random().Next(100, 200));
            numbers.Add(new Random().Next(100, 200));
            numbers.Add(new Random().Next(100, 200));
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }

        }
        void UnderstaningLimitationOfArray()
        {
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = i * 100 + new Random().Next(10, 100);
            }
            //To increase the size of array we have to create a new array and copy the old array to new array
            int[] nums1 = new int[12];
            for (int i = 0; i < 10; i++)
            {
                nums1[i] = numbers[i];
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        void UnderstaingMoreOnList()
        {
            List<Customer> customers = new List<Customer>();
            int choice = 0;
            do
            {
                Customer customer = new Customer();
                customer.GetCustomerDetaislFromConsole();
                customer.Id = customers.Count + 100;
                customers.Add(customer);
                Console.WriteLine("Do you want to continue? Then enter any number otehr than 0.");
                choice = Convert.ToInt32(Console.ReadLine());
            } while (choice != 0);
            Console.WriteLine("----------------------------------------");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

            bool isCustomerFound = customers.Contains(new Customer("rohit"));
            Console.WriteLine("Is rohit present " + isCustomerFound);

            //var index = customers.IndexOf(new Customer("rohit"));
            //Console.WriteLine(index);
            //customers.RemoveAt(index);
            //customers.Remove(new Customer("rohit"));
            customers.Sort();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

        }
        void UnderstandingDictionary()
        {
            Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
            customers.Add(100, new Customer("rohit"));
            customers.Add(101, new Customer("rahul"));  

            foreach(var item in customers.Keys)
            {
                Console.WriteLine(customers[item]);
            }
        }   
        static void Main(string[] args)
        {
            Program program = new Program();
            // program.UnderstaningLimitationOfArray();
            //program.UnderstandingCollection();/
            //program.UnderstaingMoreOnList();
            program.UnderstandingDictionary();
           
        }
    }
}

