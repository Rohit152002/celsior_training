using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class Appointment
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
        public Appointment(int id, int patientId, int doctorId,  TimeOnly appointmentTime, )
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = DateTime.Now;
            AppointmentTime=appointmentTime;
        }

        
        public override string ToString()
        {
            return $"Appointment ID: {Id}, Patient ID: {PatientId}, Doctor ID: {DoctorId}, Date: {AppointmentDate}";
        }
    }
}
