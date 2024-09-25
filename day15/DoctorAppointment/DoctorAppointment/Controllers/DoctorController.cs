using System.Net.Http.Headers;
using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;
using DoctorAppointment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            var doctors = _doctorService.GetAllDoctor();
            return View(doctors);
        }
    }

}
