using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal abstract class ClinicData
    {
        public static List<Doctor> Doctors = new List<Doctor> {
        new Doctor
        {
            Id = 1,
            Name = "Dr. John Smith",
            Specialist = "Cardiology",
            DateOfBirth = new DateTime(1980, 5, 15),
            Gender = "Male",
            Email = "john.smith@hospital.com",
            Password = "password123",
            Phone = 1234567890
        },
        new Doctor
        {
            Id = 2,
            Name = "Dr. Jane Doe",
            Specialist = "Pediatrics",
            DateOfBirth = new DateTime(1985, 8, 22),
            Gender = "Female",
            Email = "jane.doe@hospital.com",
            Password = "password123",
            Phone = 9876543210
        }};

        public static List<Patient> Patients = new List<Patient>
        {
            new Patient
            {
                Id = 1,
                Name = "Alice Brown",
                 DateOfBirth = new DateTime(1990, 4, 10),
                Email = "alice.brown@email.com",
                Gender = "Female",
                Password = "password123",
                Phone = 5551234567
            },
            new Patient
            {
                Id = 2,
                Name = "Bob White",
                DateOfBirth = new DateTime(1992, 11, 30),
                Email = "bob.white@email.com",
                Gender = "Male",
                Password = "password123",
                Phone = 5559876543
            }
    };
        public static List<Appointment> Appointments = new List<Appointment>
        {
            new Appointment
            {
            Id = 1,
            PatientId = 1,
            DoctorId = 1,
            AppointmentDate = new DateTime(2024, 10, 1),
            AppointmentTime = new TimeOnly(10, 30) // 10:30 AM
        },
        new Appointment
        {
            Id = 2,
            PatientId = 2,
            DoctorId = 2,
            AppointmentDate = new DateTime(2024, 10, 2),
            AppointmentTime = new TimeOnly(14, 0) // 2:00 PM
        }
    };

        public static List<string> Specialist = new List<string>
        {
            "Cardiology",
            "Pediatrics"
        };
    }
}
