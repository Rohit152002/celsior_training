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
                var patient = _patientService.SignIn(email, password);

                if (patient!=null)
                {
                    TempData["Name"] = patient.Name;
                    TempData["Id"]=patient.Id;
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
