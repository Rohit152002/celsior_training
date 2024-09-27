using DoctorAppointment.Models;

namespace DoctorAppointment.Interfaces
{
    public interface IDoctorService
    {
        public IEnumerable<Doctor> GetAllDoctor();
        public Doctor GetDoctorByName(string name);
    }
}
