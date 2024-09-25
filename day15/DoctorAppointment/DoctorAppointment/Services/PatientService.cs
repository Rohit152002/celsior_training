using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;

namespace DoctorAppointment.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<string, Patient> _patientRepository;

        public PatientService(IRepository<string, Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient Register(Patient patient)
        {
            return _patientRepository.Add(patient);
        }

        public bool SignIn(string email, string password)
        {
            var patient = _patientRepository.Get(email);
            return ComparePassword(patient.Password, password);
        }

        bool ComparePassword(string oldPassword, string newPassword)
        {
            return oldPassword == newPassword;
        }
    }

}
