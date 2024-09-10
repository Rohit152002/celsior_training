namespace Issue
{
    class Parent
    {
        protected string Name { get; set; } = string.Empty;
        public Parent()
        {
            Console.WriteLine("parent Constructed");
            Name = "Ramu";
        }
        public virtual void printName()
        {
            Console.WriteLine("Parent "+Name);
        }
    }
    class Child : Parent
    {
        public Child()
        {
            Console.WriteLine("Child Constructed");
            Name += "Samu";
        }
        public override void printName()
        {
            Console.WriteLine("Child" +Name);
        }
        public override string ToString()
        {
            return "Hello world string";
        }
    }
    internal class Program
    {
        Employee CreateEmployee()
        {
                      var employee = new Employee();
                Console.WriteLine("Please enter the employee Id");
                employee.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the employee Name");
                employee.Name = Console.ReadLine() ?? "";
                Console.WriteLine("Please enter the employee Designation");
                employee.Designation = Console.ReadLine() ?? "";
                Console.WriteLine("Please enter the employee Salary");
                employee.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter the employee Date of Birth");
                employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Please enter the employee Total Leave");
                employee.TotalLeave = Convert.ToInt32(Console.ReadLine());
                return employee;
           
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int? num1 = null;
            Console.WriteLine(num1);
            var program = new Program();
            Employee emp1 = program.CreateEmployee();
            //Console.WriteLine(emp1);
            emp1.show();
            string? num2 = null;
            Console.WriteLine(num2);
            Parent obj = new Parent();
            obj.printName();
            Console.WriteLine( obj.ToString());

            //var program = new Program();
            //Employee employee1 = new Employee(101, "John", "Manager", 50000, new DateTime(1980, 1, 1), 10);
            //Employee employee2 = program.CreateEmployee();
            //Issue issue1 = new Issue(1, "Chair Unavailable", "The working chair is not available in the floor", 102);
            //issue1.AssignIssue(101);
            //issue1.ChangeStatus("Closed");
            //issue1.PrintIssueDetails();
            //Console.WriteLine(issue1);
        }
    }
}
