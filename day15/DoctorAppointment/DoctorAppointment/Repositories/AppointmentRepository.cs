using DoctorAppointment.Exceptions;
using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;

namespace DoctorAppointment.Repositories
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {

        static List<Appointment> appointments = new List<Appointment>()
        {
            new Appointment() {Id=1, AppointmentDate=DateTime.Parse("2024-09-30"), DoctorId=1,PatientId=101},
        };


        public Appointment Add(Appointment entity)
        {
            if (appointments.Count == 0)
            {
                entity.Id = 1;
            }
            else
            {
                entity.Id = appointments.Max(c => c.Id) + 1;
            }
            if(entity!=null)
            {
                var alreadyAppointment = appointments.FirstOrDefault(e => (e.AppointmentDate == entity.AppointmentDate) && (e.AppointmentTime==entity.AppointmentTime));
                if(alreadyAppointment!=null)
                {
                    throw new AppointmentAlreadySelected("It is already Appointmented Select another");
                }
            }
            appointments.Add(entity);
            return entity;
        }

        public void Delete(int key)
        {
            var appointment = appointments.FirstOrDefault(c => c.Id == key);
            if (appointment == null)
            {
                throw new NoEntityFoundException("Doctor");
            }
            appointments.Remove(appointment);
        }

        public Appointment Get(int key)
        {
            var appointment = appointments.FirstOrDefault(c => c.PatientId == key);
            if (appointment == null)
            {
                throw new NoEntityFoundException("patient");
            }
            return appointment;
        }

        public IEnumerable<Appointment> GetAll()
        {
            if (appointments.Count == 0)
            {
                throw new NoEntityFoundException("No appointments found.");
            }
            return appointments;
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
