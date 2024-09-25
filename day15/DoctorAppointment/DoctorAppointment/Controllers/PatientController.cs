using System.Net.Http.Headers;
using DoctorAppointment.Exceptions;
using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;
using DoctorAppointment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace DoctorAppointment.Controllers
{
    public class PatientController : Controller
    {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public IActionResult Index()
        {
            System.Console.WriteLine("login called");
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            try
            {

                System.Console.WriteLine("login post called");
                System.Console.WriteLine("email" + email);
                System.Console.WriteLine("password" + password);
                if (_patientService.SignIn(email, password))
                {
                    return RedirectToAction("Index", "Doctor");
                }
                ViewBag.Message = "Unable to sign in";
                return View();
            }
            catch (NoEntityFoundException e)
            {
                return View();
            }
        }
    }

}
