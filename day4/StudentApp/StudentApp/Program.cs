namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(100, "rohit laishram", new DateTime(2003, 04, 15), 7642833064, "laishramrohit15@gmail.com");
            std1.displayId();
        }
    }
}
