namespace DoctorAppointment.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

        static int i = 0;
        public Appointment()
        {
            Id =i;
            i++;
            AppointmentDate = DateTime.Now;
        }
        public Appointment(int id, int patientId, int doctorId, TimeOnly appointmentTime)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = DateTime.Now;
            AppointmentTime = appointmentTime;
        }

        public override string ToString()
        {
            return $"Id : {Id}\nPatientId={PatientId}\nDoctorId={DoctorId}\n";
        }

    }
}
