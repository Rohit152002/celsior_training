using DoctorAppointment.Models;

namespace DoctorAppointment.Interfaces
{
    public interface IPatientService
    {
        public Patient SignIn(string email, string password);
        public Patient Register(Patient patient);
        public IEnumerable<Patient> AllPatients();
    }
}
