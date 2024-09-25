using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;
using DoctorAppointment.Exceptions;
using System.Runtime.InteropServices;

namespace DoctorAppointment.Repositories
{
    public class PatientRepository : IRepository<string, Patient>
    {
        List<Patient> patients = new List<Patient>()
        {
           new Patient() {Id=1, Name="Rohit", Email="abc123@gmail.com",Password="password",Gender="male",Phone=1927839183},
           new Patient() {Id=2, Name="Rajesh", Email="xyz456@gmail.com",Password="password",Gender="male",Phone=9876543210},
           new Patient() {Id=3, Name="Priya", Email="pqr789@gmail.com",Password="password",Gender="female",Phone=8765432190},
        };

        public Patient Add(Patient entity)
        {
            if (patients.Count == 0)
            {
                entity.Id = 1;
            }
            else
            {
                entity.Id = patients.Max(c => c.Id) + 1;
            }
            patients.Add(entity);
            return entity;
        }

        public void Delete(string key)
        {
            var doctor = patients.FirstOrDefault(c => c.Name == key);
            if (doctor == null)
            {
                throw new NoEntityFoundException("Doctor", key);
            }
            patients.Remove(doctor);
        }

        public Patient Get(string key)
        {
            var patient = patients.FirstOrDefault(c => c.Email == key);
            if (patient == null)
            {
                throw new NoEntityFoundException("patient", key);
            }
            return patient;
        }

        public IEnumerable<Patient> GetAll()
        {
            if (patients.Count == 0)
            {
                throw new NoEntityFoundException("No patients found.");
            }
            return patients;
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }
    }


}
