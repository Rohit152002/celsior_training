using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class DoctorService : ClinicData, IDoctorService
    {
        public Doctor DoctorLogin(string email, string password)
        {
            Doctor result = Doctors.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (result == null)
            {
                throw new IncorrectLogin("Incorrect Email or Password");
            }
            return result;
        }

        public Doctor DoctorRegister()
        {
            Doctor Doctor = new Doctor();
            bool registrationComplete = false;

            while (!registrationComplete)
            {
                try
                {
                    Console.WriteLine("=======================");
                    Console.WriteLine("Registration Process");


                    Console.Write("Enter your Name: ");
                    Doctor.Name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Doctor.Name))
                    {
                        throw new FormatException("Name cannot be empty.");
                    }


                    Console.Write("Enter your Date of Birth (DD/MM/YYYY): ");
                    string input = Console.ReadLine();

                    try
                    {
                        // Parse the input date with the specified format
                        Doctor.DateOfBirth = DateTime.ParseExact(input, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid date format. Please use DD/MM/YYYY.");
                    }



                    Console.Write("Enter your Gender (e.g., Male/Female): ");
                    Doctor.Gender = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Doctor.Gender))
                    {
                        throw new FormatException("Gender cannot be empty.");
                    }

                    Console.Write("Enter your Specialist: ");
                    Doctor.Specialist = Console.ReadLine();
                    if(!Specialist.Contains(Doctor.Specialist))
                    {
                        Specialist.Add(Doctor.Specialist);
                    }

                    Console.Write("Enter your Phone number: ");
                    Doctor.Phone = Convert.ToDouble(Console.ReadLine());


                    Console.Write("Enter your Email: ");
                    Doctor.Email = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Doctor.Email) || !Doctor.Email.Contains("@"))
                    {
                        throw new FormatException("Email is not valid.");
                    }

                    Console.Write("Enter your Password: ");
                    Doctor.Password = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Doctor.Password))
                    {
                        throw new FormatException("Password cannot be empty.");
                    }
                    Doctors.Add(Doctor);
                    Console.WriteLine("Registration Successful");
                    registrationComplete = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Please re-enter your details.");
                }
            }
            return Doctor;
        }

        public void ViewAllAppointMent(int id)
        {
            Console.WriteLine("List of Appointment");
            var doctorAppoinments = Appointments.Where(a => a.DoctorId == id).ToList();

            if (doctorAppoinments.Any())
            {
                foreach (var appointment in doctorAppoinments)
                {
                    Console.WriteLine(appointment);
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.WriteLine("==============");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("No appointments found");
            }
        }

        public void ViewAllPatient()
        {
            Console.WriteLine("============================");
            Console.WriteLine("List of Patient : ");
            //Console.WriteLine(Patients);
            if (Patients.Count < 0 || Patients == null)
            {
                Console.WriteLine("No Paitent Available");
                throw new NullReferenceException("No Paitent Available");
            }
            else
            {
                foreach (var patient in Patients)
                {
                    Console.WriteLine(patient);
                }

            }
        }
    }
}
