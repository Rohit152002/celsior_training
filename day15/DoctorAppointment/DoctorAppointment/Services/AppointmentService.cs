using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace DoctorAppointment.Services
{

    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<int, Appointment> _appointmentRepository;
        public AppointmentService(IRepository<int, Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public Appointment CreateNewAppointment(Appointment appointment)
        {
            Console.WriteLine("Appointment Created");
            return _appointmentRepository.Add(appointment);
        }

        public IEnumerable<Appointment> ShowAllAppointmentById(int id)
        {
            var appointments = _appointmentRepository.GetAll().ToList();
            var patientAppointment= appointments.FindAll(x=>x.PatientId == id);

            return patientAppointment;
           
        }

        public List<string> GetAvailableTimeSlots(DateTime date, int doctorId)
        {

            TimeOnly startTime = new TimeOnly(8, 0);
            TimeOnly endTime = new TimeOnly(17, 0);


            var lastAppointmentTime = _appointmentRepository.GetAll()
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date)
                .OrderByDescending(a => a.AppointmentTime)
                .Select(a => a.AppointmentTime)
                .FirstOrDefault();

            var bookTimes = _appointmentRepository.GetAll().Where(a => a.DoctorId == doctorId && a.AppointmentDate == date).Select(a => a.AppointmentTime).ToHashSet();

            //TimeOnly startSlot = lastAppointmentTime == default ? startTime : lastAppointmentTime.Add(new TimeSpan(0, 30, 0));
            TimeOnly startSlot = startTime;

            var timeSlots = new List<string>();
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);


            bool isToday = date.Date == DateTime.Today;
            for (TimeOnly time = startSlot; time <= endTime; time = time.Add(new TimeSpan(0, 30, 0)))
            {
                if (isToday && time <= currentTime)
                {
                    continue;
                }
                //if (!_appointmentRepository.GetAll().Any(a =>
                //    a.DoctorId == doctorId &&
                //    a.AppointmentDate == date &&
                //    a.AppointmentTime == time))
                //{
                //    timeSlots.Add(time.ToString());
                //}
                if (!bookTimes.Contains(time))
                {
                    timeSlots.Add(time.ToString());
                }
                else
                {
                    // If the time is booked, skip to the next available hour
                    time = time.Add(new TimeSpan(1, 0, 0)); // Skip to the next hour
                }
            }

            return timeSlots;
        }

    }
}
