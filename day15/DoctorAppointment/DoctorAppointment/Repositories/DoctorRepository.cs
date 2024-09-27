using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;
using DoctorAppointment.Exceptions;
using System.Runtime.InteropServices;

namespace DoctorAppointment.Repositories
{
    public class DoctorRepository : IRepository<string, Doctor>
    {
        static List<Doctor> doctors = new List<Doctor>()
        {
           new Doctor() {Id=1, Name="Rahul", Email="rohit@gmail.com",Specialist="GastroLogist",Image="rohit.jpg"},
           new Doctor() {Id=2, Name="Rajesh", Email="rajesh@gmail.com",Specialist="Orthologies",Image="rajesh.jpg"},
           new Doctor() {Id=3, Name="Priya", Email="priya@gmail.com", Specialist="Physicist",Image="priya.jpg"},
        };

        public Doctor Add(Doctor entity)
        {
            if (doctors.Count == 0)
            {
                entity.Id = 1;
            }
            else
            {
                entity.Id = doctors.Max(c => c.Id) + 1;
            }
            doctors.Add(entity);
            return entity;
        }

        public void Delete(string key)
        {
            var doctor = doctors.FirstOrDefault(c => c.Name == key);
            if (doctor == null)
            {
                throw new NoEntityFoundException("Doctor", key);
            }
            doctors.Remove(doctor);
        }

        public Doctor Get(string key)
        {
            var doctor = doctors.FirstOrDefault(c => c.Name == key);
            if (doctor == null)
            {
                throw new NoEntityFoundException("patient", key);
            }
            return doctor;
        }

        public IEnumerable<Doctor> GetAll()
        {
            if (doctors.Count == 0)
            {
                throw new NoEntityFoundException("No doctors found.");
            }
            return doctors;
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }


}
