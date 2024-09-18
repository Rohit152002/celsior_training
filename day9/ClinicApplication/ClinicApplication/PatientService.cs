using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class PatientService : ClinicData, IPatientService
    {
        public void BookAppointMent(int patientId)
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

                    appointment.PatientId = patientId;

                    Console.Write("Enter Appointment Date (DD/MM/YYYY): ");
                    string input = Console.ReadLine();

                    try
                    {
                        // Parse the input date with the specified format
                        appointment.AppointmentDate = DateTime.ParseExact(input, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        // Check if the date is today or in the future
                        if (appointment.AppointmentDate.Date < DateTime.Today)
                        {
                            Console.WriteLine("Appointment date cannot be in the past. Please enter a date today or in the future.");
                        }
                    }
                    catch (FormatException)
                    {
                       throw new FormatException("Invalid date format. Please use DD/MM/YYYY.");
                    }


                    // Doctor ID input
                    ViewAllSpecialist();

                    int specialListIndex= Convert.ToInt32(Console.ReadLine());
                    string specialList = Specialist[specialListIndex-1];

                    var specialists = Doctors
                                            .Select(d => d.Specialist)
                                            .Distinct()
                                            .OrderBy(s => s)
                                            .ToList();

                    if (specialListIndex > 0 && specialListIndex <= specialists.Count)
                    {
                        string selectedSpecialty = specialists[specialListIndex - 1];
                        Console.WriteLine($"Selected Specialty: {selectedSpecialty}");

                

                        // Get an available doctor
                        Doctor availableDoctor = GetAvailableDoctor(selectedSpecialty,  DateTime.Now, TimeOnly.FromDateTime(DateTime.Now) );

                        if (availableDoctor != null)
                        {
                            Console.WriteLine($"Available Doctor: ID: {availableDoctor.Id}, Name: {availableDoctor.Name}, Email: {availableDoctor.Email}, Phone: {availableDoctor.Phone}");

                            // Create a new appointment and assign the available doctor
                            appointment.DoctorId = availableDoctor.Id;
                            Console.WriteLine($"Appointment created with Doctor ID: {appointment.DoctorId}");
                        }
                        else
                        {
                            Console.WriteLine("No available doctors for the selected specialty at the specified time.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }




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
                        Console.WriteLine("Appointment booked successfully.");
                        Appointments.Add(appointment);
                        bookingComplete = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Please re-enter your details.");
                }
            }


        }

        public Doctor GetAvailableDoctor(string specialty, DateTime date, TimeOnly time)
        {
            // Get doctors by specialty
            var doctorsBySpecialty = Doctors
                .Where(d => d.Specialist.Equals(specialty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Get IDs of doctors with appointments at the given date and time
            var unavailableDoctorIds = Appointments
                .Where(a => a.AppointmentDate.Date == date.Date && a.AppointmentTime == time)
                .Select(a => a.DoctorId)
                .Distinct()
                .ToHashSet();

            // Find the first available doctor
            var availableDoctor = doctorsBySpecialty
                .FirstOrDefault(d => !unavailableDoctorIds.Contains(d.Id));

            return availableDoctor;
        }


        public Patient PatientLogin(string email, string password)
        {
            Patient result = Patients.FirstOrDefault(p=>p.Email==email && p.Password==password);
            Console.WriteLine(result);
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
                    string input = Console.ReadLine();

                    try
                    {
                        // Parse the input date with the specified format
                        patient.DateOfBirth = DateTime.ParseExact(input, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid date format. Please use DD/MM/YYYY.");
                    }




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
                    Patients.Add(patient);
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
                Console.WriteLine("There is no doctor ");
                throw new NullReferenceException("There is no Doctor available");
            }
            foreach (var doctor in Doctors)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("==============");
                Console.ResetColor();
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
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

           
            bool isToday = date.Date == DateTime.Today;
            for (TimeOnly time = startSlot; time <= endTime; time = time.Add(new TimeSpan(0, 30, 0))) 
            {
                if (isToday && time <= currentTime)
                {
                    continue;
                }
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

        private void ViewAllSpecialist()
        {
            int i = 1;
            Console.WriteLine("Select one Specialist: ");
            foreach(var item in Specialist)
            {
                Console.WriteLine($"{i}. {item}");
                i++;
            }
        }
    }
}
