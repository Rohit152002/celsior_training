using System.Numerics;

namespace ClinicApplication
{
    internal class Program
    {
        IDoctorService DoctorService;
        IPatientService PatientService;
        public Program()
        {
            DoctorService = new DoctorService();
            PatientService = new PatientService();
        }
        void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================");
            Console.WriteLine("Clinic Management System ");
            Console.WriteLine("Enter a choice ( 0 to exit): ");
            Console.WriteLine("1. Patient");
            Console.WriteLine("2. Doctor");
            Console.WriteLine("0. Exit");
            Console.ResetColor();
        }

        void RegisterOrLoginMenu()
        {
            Console.WriteLine("1. Register ");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");

        }

        void PatientUserMenu()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("==============");
            Console.WriteLine("1. List Of Doctors");
            Console.WriteLine("2. Book Appointment");
            Console.WriteLine("3. View Appointment");
            Console.WriteLine("0. Exit");

            Console.ResetColor();
        }

        void DoctorUserMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==============");
            Console.WriteLine("1. List all Appointment");
            Console.WriteLine("2. View all Patient");
            Console.WriteLine("0. Exit");

            Console.ResetColor();
        }

        void DoctorUserInteraction(Doctor doctor)
        {
            if (doctor != null)
            {
                int choice;
                do
                {
                DoctorUserMenu();
                    try
                    {
                      
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                try
                                {
                                    DoctorService.ViewAllAppointMent(doctor.Id);
                                }
                                catch (Exception ex)
                                {  
                                    Console.WriteLine($"An error occurred while viewing appointments: {ex.Message}");
                                }
                                break;

                            case 2:
                                try
                                {
                                    DoctorService.ViewAllPatient();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An error occurred while viewing patients: {ex.Message}");
                                }
                                break;
                            case 0:
                                break;

                            default:
                                Console.WriteLine("Enter a valid number!!");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input format. Please enter a number.");
                        choice = -1; 
                    }
                    catch (OverflowException)
                    {
                        
                        Console.WriteLine("Number is too large or too small. Please enter a valid number.");
                        choice = -1;
                    }
                    catch(NullReferenceException e)
                    {
                        Console.WriteLine(e.Message);
                        choice = -1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        choice = -1; 
                    }
                }
                while (choice != 0);
            }
        }
        void DoctorRegister()
        {
            Doctor doctor = DoctorService.DoctorRegister();
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("Registered successfully");
            Console.ResetColor();
            Console.WriteLine(doctor);
            DoctorUserInteraction(doctor);

        }

        void DoctorLogin()
        {
            try
            {
                Console.WriteLine("======================");
                Console.Write("Enter your Email: ");
                string Email = Console.ReadLine();
                Console.Write("Enter your password: ");
                string Password = Console.ReadLine();
                Doctor doctor = DoctorService.DoctorLogin(Email, Password);
                Console.WriteLine(doctor);
                DoctorUserInteraction(doctor);
            }catch(IncorrectLogin e)
            {
                Console.WriteLine(e.Message);
            }catch (Exception e) 
            { 
                Console.WriteLine(e.Message);
            }
        

        }

        void PatientLogin()
        {
            try
            {
                Console.WriteLine("======================");
                Console.WriteLine("Patient Login");
                Console.Write("Enter your Email: ");
                string Email = Console.ReadLine();
                Console.Write("Enter your password: ");
                string Password = Console.ReadLine();
                Patient patient = PatientService.PatientLogin(Email, Password);
                //Console.WriteLine(patient);
                PatientUserInteraction(patient);
            }
            catch (IncorrectLogin e)
            {
                Console.WriteLine(  e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        void DoctorUserRegisterOrLogin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=================");
            int choice;
            do
            {
                RegisterOrLoginMenu();
                
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DoctorRegister();
                        break;
                    case 2:
                        DoctorLogin();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }

            } while (choice != 0);
        }
        void Doctor()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Doctor ");
            DoctorUserRegisterOrLogin();
            

        }

        void PatientUserRegisterOrLogin()
        {
            int choice;
            do
            {
                RegisterOrLoginMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PatientRegister();
                        break;
                    case 2:
                        PatientLogin();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            } while (choice != 0);
        }

        void PatientUserInteraction(Patient patient)
        {
            if (patient != null)
            {
                int choice;
                do
                {
                    PatientUserMenu();
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            PatientService.SeeAllDoctorList();
                            break;
                        case 2:
                            PatientService.BookAppointMent(patient.Id);
                            break;
                        case 3:
                            PatientService.ViewAppointMent(patient.Id);
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Enter a valid number!!");
                            break;
                    }
                }
                while (choice != 0);
            }
        }

        void PatientRegister()
        {
            Patient patient = PatientService.PatientRegister();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Registered successfully");
            Console.ResetColor();
            Console.WriteLine(patient);
            PatientUserInteraction(patient);
        }
        
        void Patient()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Patient ");
        
            PatientUserRegisterOrLogin();
        }

        void FirstUserInteraction()
        {
            int choice;
            do
            {
                PrintMenu();
                choice=Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        Patient();
                        break;
                    case 2:
                        Doctor();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }

            }
            while (choice !=0);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.FirstUserInteraction();
        }
    }
}
