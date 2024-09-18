using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class Appointment:ClinicData
    {
        public int Id { get; set; }              
        public int PatientId { get; set; }         
        public int DoctorId { get; set; }          
        public DateTime AppointmentDate { get; set; } 
        public TimeOnly AppointmentTime { get; set; }
        
        static int i = 0;
        public Appointment()
        {
            Id = 100 + i;
            i++;
        }
        public Appointment(int id, int patientId, int doctorId,  TimeOnly appointmentTime)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = DateTime.Now;
            AppointmentTime=appointmentTime;    
        }

        
        public override string ToString()
        {
            var patient = Patients.FirstOrDefault(p => p.Id == PatientId);
            var doctor = Doctors.FirstOrDefault(d => d.Id == DoctorId);

            return $"Appointment ID: {Id},\nPatient Name: {patient.Name},\nDoctor Name: {doctor.Name},\nDate: {AppointmentDate.ToString("dd/MM/yyyy")},\n{AppointmentTime.ToString("hh:mm tt")} ";
        }
    }
}
