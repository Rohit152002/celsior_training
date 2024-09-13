namespace EmployeeDetail
{
    internal class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Find Employee by ID");
            Console.WriteLine("3. Display Employees Sorted by Salaries");
            Console.WriteLine("4. Find Employees by Name");
            Console.WriteLine("5. Find employees to compare age");
            Console.WriteLine("6. Print all Employees");
            Console.WriteLine("7. Modification Employee By Id");
            Console.WriteLine("8. Deletion Employee By Id");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
        }

        static void Main()
        {
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
            EmployeeService employeeService = new EmployeeService();

            int choice = 1;
            do
            {
                try
                {
                    PrintMenu();
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Employee employee = new Employee();
                            employee.TakeEmployeeDetailsFromUser();
                            if (employees.ContainsKey(employee.Id))
                            {
                                throw new DuplicateKeyErrorException("Key is already declared.");
                            }
                            employees.Add(employee.Id, employee);
                            Console.WriteLine("Employee added successfully.");
                            break;

                        case 2:
                            Console.Write("Enter Employee ID to find: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Employee employeeById = employeeService.FindEmployeeByID(id, employees);
                            Console.WriteLine(employeeById != null ? employeeById.ToString() : "Employee not found.");
                            break;

                        case 3:
                            Console.WriteLine("Employees sorted by salaries:");
                            employeeService.SortedBySalaries(employees);
                            break;

                        case 4:
                            Console.Write("Enter employee name to find: ");
                            string inputName = Console.ReadLine();
                            List<Employee> listOfUser = employeeService.ListOfUserByName(employees, inputName);
                            Console.WriteLine($"Found {listOfUser.Count} employees with the name {inputName}.");
                            foreach (var emp in listOfUser)
                            {
                                Console.WriteLine($"List of Users who are elder than {emp.Name}, ID: {emp.Id}");
                                employeeService.ListOfUserWhichAreElder(employees, emp.Age);
                            }
                            break;
                        case 5:
                            Console.Write("Enter Employee ID to find: ");
                            int Empid = Convert.ToInt32(Console.ReadLine());
                            Employee EmployeeId = employeeService.FindEmployeeByID(Empid, employees);
                            employeeService.ListOfUserWhichAreElder(employees, EmployeeId.Age);
                            break;

                        case 6:
                            employeeService.PrintAllEmployees(employees);
                            break;

                        case 7:
                            employeeService.Modification(employees);
                            break;

                        case 8:
                            employeeService.Deletion(employees);
                            break;

                        case 0:
                            Console.WriteLine("Exiting the program.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please enter a number between 0 and 7.");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Format error: {e.Message}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Argument error: {e.Message}");
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine($"Key not found error: {e.Message}");
                }
                catch (DuplicateKeyErrorException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (choice != 0);
        }
    }
}
