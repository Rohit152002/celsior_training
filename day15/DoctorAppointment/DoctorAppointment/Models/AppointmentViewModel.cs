namespace DoctorAppointment.Models
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public List<string> AvailableSlots { get; set; }
    }
}
