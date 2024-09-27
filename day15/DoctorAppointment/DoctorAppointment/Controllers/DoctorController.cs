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

        public IActionResult Index(string searchString)
        {
            Console.WriteLine(searchString);
            ViewData["CurrentFilter"] = searchString;
            var doctors = _doctorService.GetAllDoctor();

            if(!String.IsNullOrEmpty(searchString))
            {
                var searchDoctor = doctors.Where(e=>e.Name.ToLower().Contains(searchString.ToLower()));
                Console.WriteLine(searchDoctor);
                return View(searchDoctor);
            }
            ViewBag.Name = TempData["Name"];
            ViewBag.Id=TempData["Id"];
            return View(doctors);
        }
    }

}
