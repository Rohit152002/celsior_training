using DoctorAppointment.Models;

namespace DoctorAppointment.Interfaces
{
    public interface IPatientService
    {
        public bool SignIn(string email, string password);
        public Patient Register(Patient patient);
    }
}
