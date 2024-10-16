using HospitalApplication.Context;
using HospitalApplication.Interfaces;
using HospitalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Services
{

    public class PatientService : IPatientService
    {
        ClinicContext context= new ClinicContext();
        Appointment PopulateNewAppointment()
        {

            Appointment appointment = new Appointment();
            Console.Write("Please enter your id: ");
            appointment.PatientId=Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter your appointment date (DD/MM/YYYY HH:mm) : ");
            appointment.AppointmentDate=Convert.ToDateTime(Console.ReadLine());
            var appointments = context.Appointments.ToList();

            appointments = appointments.Where(x => x.AppointmentDate == appointment.AppointmentDate).ToList();
            if ( appointments.Count != 0)
            {
                throw new Exception("Appointment is already book");
            }
            Console.Write("Please enter the doctor Id: ");
            appointment.DoctorId=Convert.ToInt32(Console.ReadLine());
            return appointment;
        }
       
        public void BookAppointMent()
        {
            Console.WriteLine("Appointment Booking Process");
            Appointment appointment = PopulateNewAppointment();
            try
            {
                context.Appointments.Add(appointment);
                context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Registration failed");
            }
            //throw new NotImplementedException();
        }


        public void ViewAppointMent()
        {
            var appointments= context.Appointments.ToList();
            PrintAppointments(appointments);

        }

        void PrintAppointments(List<Appointment> appointments)
        {
            foreach (Appointment appointment in appointments)
            {
                Console.WriteLine($"Appointment Id: {appointment.Id}\nAppointment PatientId{appointment.PatientId}\nAppointment DoctorId: {appointment.DoctorId}\nAppointment Date : {appointment.AppointmentDate}");
            }
        }

        Patient PopulateNewPatient()
        {
            Patient patient = new Patient();
            Console.Write("Please Enter your Name: ");
            patient.Name = Console.ReadLine();
            Console.Write("Please Enter your Gender: ");
            patient.Gender = Console.ReadLine();
            Console.Write("Please Enter your Phone no. :- ");
            patient.Phone = Convert.ToDouble(Console.ReadLine());
            return patient;
        }

        public void RegisterPatient()
        {
            Patient patient = PopulateNewPatient();
            context.Patients.Add(patient);
            context.SaveChanges();
        }
    }
}
