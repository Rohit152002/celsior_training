using DoctorAppointment.Exceptions;
using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace DoctorAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public ActionResult Index(int id)
        {
            Console.WriteLine("Appointment Index");
                Console.WriteLine(id);
            try
            {
                var appointments = _appointmentService.ShowAllAppointmentById(id);
                Console.WriteLine(appointments.Count());
                return View(appointments);
            }catch(NoEntityFoundException e)
            {
                return RedirectToAction("Empty");
            }
        }
        [HttpGet]
        public IActionResult Create(int doctorId, int patientId)
        {
            var doctors = _doctorService.GetAllDoctor();
            var patients = _patientService.AllPatients();
            var doctor=doctors.FirstOrDefault(e=>e.Id == doctorId);
            var patient=patients.FirstOrDefault(e=>e.Id==patientId);
            Appointment appointment = new Appointment();
            appointment.DoctorId = doctor.Id;
            appointment.PatientId = patientId;
            var availableSlots = _appointmentService.GetAvailableTimeSlots(appointment.AppointmentDate, appointment.DoctorId);
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel()
            {
                Doctor = doctor,
                Patient = patient,
                Appointment = appointment,
                AvailableSlots=availableSlots,
            };

            return View(appointmentViewModel);
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            try
            {

            Appointment newAppointment= _appointmentService.CreateNewAppointment(appointment);
            if(newAppointment!=null)
            {
                return RedirectToAction("Index", new {id=newAppointment.PatientId});
            }
            else
            {
                return RedirectToAction("Empty");
            }
            }catch (AppointmentAlreadySelected e)
            {
                var appointmentViewModel = GetAppointmentViewModel(appointment.DoctorId, appointment.PatientId, appointment.AppointmentDate);

                ViewBag.Message = e.Message;
                return View(appointmentViewModel);
            }
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }


        public ActionResult Empty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAvailableTimeSlots(DateTime appointmentDate, int doctorId)
        {
            Console.WriteLine(doctorId + "doctor id");
            var availableSlots = _appointmentService.GetAvailableTimeSlots(appointmentDate, doctorId);
            return Json(availableSlots);
        }

        private AppointmentViewModel GetAppointmentViewModel(int doctorId, int patientId, DateTime? appointmentDate = null)
        {
            var doctors = _doctorService.GetAllDoctor();
            var patients = _patientService.AllPatients();
            var doctor = doctors.FirstOrDefault(e => e.Id == doctorId);
            var patient = patients.FirstOrDefault(e => e.Id == patientId);

            Appointment appointment = new Appointment
            {
                DoctorId = doctor.Id,
                PatientId = patientId,
                AppointmentDate = appointmentDate ?? DateTime.Now // Use provided date or current date
            };

            var availableSlots = _appointmentService.GetAvailableTimeSlots(appointment.AppointmentDate, appointment.DoctorId);

            return new AppointmentViewModel
            {
                Doctor = doctor,
                Patient = patient,
                Appointment = appointment,
                AvailableSlots = availableSlots
            };
        }
    }
}
