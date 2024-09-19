using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
       
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Customer = new Customer { Id = 1, Name = "Rohit", Age = 12 };
            ViewData["Customer Name"] = "Rohit Laishram";
            return View();
        }

        public IActionResult ViewCustomerData()
        {
            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 12 };
            return View(customer);
        }

    }
}
