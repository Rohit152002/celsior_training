using Microsoft.AspNetCore.Mvc;
using UnderstandingStructure.Interfaces;

namespace UnderstandingStructure.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            try
            {
                var pizzas = _pizzaService.GetAllPizzas();
                return View(pizzas);
            }
            catch(System.Exception ex)
            {
                ViewBag.ErrorMessage ="There was an error in retrieving " +  ex.Message;  
                return View();
            }
        }
    }
}
