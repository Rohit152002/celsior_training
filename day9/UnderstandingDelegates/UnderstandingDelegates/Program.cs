namespace UnderstandingDelegates
{
    internal class Program
    {
        //no need to declare if there is already a predefined delegate which do not have any  return type 
        //public delegate void CalculateDelegate(int n1, int n2);

        public Program()
        {
            //CalculateDelegate calculateDelegate = new CalculateDelegate(Multiply);

            
            Action<int, int> calculateDelegate = Multiply; //predefined delegate without return type 
            calculateDelegate += Add;//Multicast Delegate
            calculateDelegate += Subtract;
            Calculate(calculateDelegate, 10, 20);
        }
        public void Add(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine($"The sum of {num1} and {num2} is {result}");
        }
        public void Multiply(int num1, int num2)
        {
            int result = num1 * num2;
            Console.WriteLine($"The product of {num1} and {num2} is {result}");
        }
        public void Subtract(int num1, int num2)
        {
            int result = num2 - num1;
            Console.WriteLine($"The subract of {num1} and {num2} is {result}");
        }

        void UnderstandingTheUseOfDelegate()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mark", Salary = 5000 },
                new Employee { ID = 102, Name = "John", Salary = 10000 },
                new Employee { ID = 103, Name = "Smith", Salary = 14000 },
                new Employee { ID = 104, Name = "Watson", Salary = 15000 }
            };
            Console.WriteLine("Please enter the employee Name");
            string name = Console.ReadLine();
            //Employee employee = null;
            //for (int i = 0; i < employees.Count; i++)
            //{
            //    if (employees[i].Name==name)
            //        employee = employees[i];
            //}
            // Predicate<Employee> employeePredicate = new Predicate<Employee>(e=>e.Name==name);//Lambda Expression
            Employee employee = employees.Find(new Predicate<Employee>(e => e.Name == name));

            var employeeDetail= employees.FirstOrDefault(e=>e.Name == name);
            if (employee != null)
                Console.WriteLine(employee);
            else
                Console.WriteLine("Employee not found");
        }

        //-----------------------------------------------------------------------------
        public void Calculate(Action<int,int> myDelegate, int n1, int n2)
        {
            myDelegate(n1, n2);

        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
