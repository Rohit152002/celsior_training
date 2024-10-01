namespace Destructor
{
    internal class Program
    {

        void TestEmployee()
        {
            using (Employee employee = new Employee())
            {
                Console.WriteLine(employee.Name);
                Console.WriteLine(employee[2]);
                Console.WriteLine(employee["Apple"]);
                if(employee.AvailSickLeave(11))
                    Console.WriteLine("Approved");
                else Console.WriteLine("Rejected");
            }
        }
        void HandleProduct()
        {
            Product product1 = new Product() { Id = 101, Name = "Laptop", Price = 50000 };
            Product product2 = new Product() { Id = 102, Name = "Mobile", Price = 20000 };
            Product product = product1 + product2;
            Console.WriteLine(product);
        }

        void HandlingPrivateConstructor()
        {
            Connection connection1 = Connection.GetConnection();
            connection1.ConnectionName = "MyConnection - one";
            Console.WriteLine(connection1.ConnectionName);
            //nonew object will be created
            Connection connection2 = Connection.GetConnection();//the same object will be given
            connection2.ConnectionName = "MyConnection - two";
            Console.WriteLine(connection2.ConnectionName);
            Console.WriteLine("Print from the first reference");
            Console.WriteLine(connection1.ConnectionName);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.TestEmployee();
        }
    }
}
