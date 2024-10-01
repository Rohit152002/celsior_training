using DoctorAppointment.Models;

namespace DoctorAppointment.Interfaces
{
    public interface IAppointmentService
    {
         Appointment CreateNewAppointment(Appointment appointment);
        IEnumerable<Appointment> ShowAllAppointmentById(int id);
        public List<string> GetAvailableTimeSlots(DateTime date, int doctorId);
        public void hello();
    }
}
