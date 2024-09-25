using Microsoft.AspNetCore.Mvc;
using UnderstandingLayeredStructure.Interfaces;
using UnderstandingLayeredStructure.Models;

namespace UnderstandingLayeredStructure.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginService;

        public LoginController(ILoginServices loginService)
        {
            _loginService = loginService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
        
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            User? user = null;
            try
            {
                user = _loginService.LoginUser(email, password);
                Console.WriteLine("call");
                //return View(User);
                HttpContext.Session.SetString("name", user.Name);
                return RedirectToAction("Successfull", user);

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "There was an error "+e;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Successfull(User user)
        {
            ViewBag.name= HttpContext.Session.GetString("name");
            return View(user);
        }

        public IActionResult UnSuccessfull()
        {
            return View();
        }
    }
}
