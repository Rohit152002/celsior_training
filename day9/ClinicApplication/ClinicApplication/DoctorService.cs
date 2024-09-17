using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class DoctorService : ClinicService, IDoctorService
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

        public Doctor DoctorRegister(string name,string gender, string specialist, DateTime dateOfBirth, string email, string password, double phone)
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
                    Doctor.DateOfBirth = Convert.ToDateTime(Console.ReadLine());



                    Console.Write("Enter your Gender (e.g., Male/Female): ");
                    Doctor.Gender = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Doctor.Gender))
                    {
                        throw new FormatException("Gender cannot be empty.");
                    }

                    Console.Write("Enter your Specialist: ");
                    Doctor.Specialist = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter your Phone number: ");
                    Doctor.Phone = Convert.ToDouble(Console.ReadLine());


                    Console.Write("Enter your Email: ");
                    Doctor.Email = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Datient.Email) || !patient.Email.Contains("@"))
                    {
                        throw new FormatException("Email is not valid.");
                    }


                    Console.Write("Enter your Password: ");
                    patient.Password = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(patient.Password))
                    {
                        throw new FormatException("Password cannot be empty.");
                    }

                    Console.WriteLine("Registration Successful");
                    registrationComplete = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Please re-enter your details.");
                }
            }
            return patient;
        }

        public void ViewAllAppointMent(int id)
        {
            throw new NotImplementedException();
        }

        public void ViewAllPatient()
        {
            throw new NotImplementedException();
        }
    }
}
