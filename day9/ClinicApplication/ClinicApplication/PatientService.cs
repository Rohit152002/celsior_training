using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class PatientService : ClinicService, IPatientService
    {
        public void BookAppointMent()
        {
            Appointment appointment = new Appointment();
            bool bookingComplete = false;

            while (!bookingComplete)
            {
                try
                {
                    Console.WriteLine("=======================");
                    Console.WriteLine("Appointment Booking Process");

                

                    // Patient ID input
                    Console.Write("Enter Patient ID: ");
                    appointment.PatientId = Convert.ToInt32(Console.ReadLine());

                    // Doctor ID input
                    Console.Write("Enter Doctor ID: ");
                    appointment.DoctorId = Convert.ToInt32(Console.ReadLine());

                    var availableSlots = GetAvailableTimeSlots(appointment.AppointmentDate, appointment.DoctorId);
                    if (!availableSlots.Any())
                    {
                        Console.WriteLine("No available slots for the selected date.");
                        return;
                    }

                    Console.WriteLine("Available Time Slots:");
                    for (int i = 0; i < availableSlots.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {availableSlots[i]}");
                    }
                    Console.Write("Select a time slot by number (default is the first available): ");
                    int slotChoice = Convert.ToInt32(Console.ReadLine());
                    if (slotChoice > 0 && slotChoice <= availableSlots.Count)
                    {
                        appointment.AppointmentTime = TimeOnly.Parse(availableSlots[slotChoice - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Appointment booked successfully.");
                        bookingComplete = true;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Please re-enter your details.");
                }
            }


        }

        public Patient PatientLogin(string email, string password)
        {
            Patient result = Patients.FirstOrDefault(p=>p.Email==email && p.Password==password);
            if (result == null )
            {
                throw new IncorrectLogin("Incorrect Email or Password");
            }
            return result;

        }

        public Patient PatientRegister()
        {
            Patient patient = new Patient();
            bool registrationComplete = false;

            while (!registrationComplete)
            {
                try
                {
                    Console.WriteLine("=======================");
                    Console.WriteLine("Registration Process");


                    Console.Write("Enter your Name: ");
                    patient.Name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(patient.Name))
                    {
                        throw new FormatException("Name cannot be empty.");
                    }


                    Console.Write("Enter your Date of Birth (DD/MM/YYYY): ");
                    patient.DateOfBirth = Convert.ToDateTime(Console.ReadLine());



                    Console.Write("Enter your Gender (e.g., Male/Female): ");
                    patient.Gender = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(patient.Gender))
                    {
                        throw new FormatException("Gender cannot be empty.");
                    }


                    Console.Write("Enter your Phone number: ");
                    patient.Phone = Convert.ToDouble(Console.ReadLine());


                    Console.Write("Enter your Email: ");
                    patient.Email = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(patient.Email) || !patient.Email.Contains("@"))
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

        public void SeeAllDoctorList()
        {
            Console.WriteLine("============================");
            Console.WriteLine("List of doctor : ");
            if (Doctors.Count < 0)
            {
                throw new NullReferenceException("There is no Doctor available");
            }
            foreach (var doctor in Doctors)
            {
                Console.WriteLine(doctor);
            }
        }



        public void ViewAppointMent(int patientId)
        {
            Console.WriteLine("List of Appointment for Patient " + patientId);
            var patientAppointments = Appointments.Where(a => a.PatientId == patientId).ToList();

            if(patientAppointments.Any())
            {
                foreach(var appointment in patientAppointments)
                {
                    Console.WriteLine(appointment);
                }
            }
            else
            {
                Console.WriteLine("No appointments found for this patient");
            }
        }

        private List<string> GetAvailableTimeSlots(DateTime date, int doctorId)
        {

            TimeOnly startTime = new TimeOnly(8, 0); 
            TimeOnly endTime = new TimeOnly(17, 0); 

            
            var lastAppointmentTime = Appointments
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date)
                .OrderByDescending(a => a.AppointmentTime)
                .Select(a => a.AppointmentTime)
                .FirstOrDefault();

            
            TimeOnly startSlot = lastAppointmentTime == default ? startTime : lastAppointmentTime.Add(new TimeSpan(0, 30, 0));

            var timeSlots = new List<string>();
            for (TimeOnly time = startSlot; time <= endTime; time = time.Add(new TimeSpan(0, 30, 0))) 
            {
                if (!Appointments.Any(a =>
                    a.DoctorId == doctorId &&
                    a.AppointmentDate == date &&
                    a.AppointmentTime == time))
                {
                    timeSlots.Add(time.ToString());
                }
            }

            return timeSlots;
        }
    }
}
