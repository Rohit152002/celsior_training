using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;

namespace DoctorAppointment.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<string, Doctor> _doctorRepository;
        public DoctorService(IRepository<string, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public IEnumerable<Doctor> GetAllDoctor()
        {
            var doctors = _doctorRepository.GetAll();
            return doctors;
        
        }
        public Doctor GetDoctorByName(string name)
        {
            var doctor = _doctorRepository.Get(name);
            return doctor;
        }
    }
}
