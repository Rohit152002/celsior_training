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

        public IEnumerable<Patient> AllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient SignIn(string email, string password)
        {
            var patient = _patientRepository.Get(email);
            if (ComparePassword(patient.Password, password)){
                return patient;
            }
            else
            {
                return null;
            }
        }

        
        bool ComparePassword(string oldPassword, string newPassword)
        {
            return oldPassword == newPassword;
        }
    }

}
