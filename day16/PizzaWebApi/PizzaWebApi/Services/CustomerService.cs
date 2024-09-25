using PizzaWebApi.Interfaces;
using PizzaWebApi.Models;

namespace PizzaWebApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int, Pizza> _pizzaRepository;

        public CustomerService(IRepository<int, Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        public async Task<IEnumerable<Pizza>> ViewPizzas()
        {
            var pizzas = (await _pizzaRepository.GetAll()).ToList().OrderBy(p => p.Name);
            return pizzas;
        }
    }
}
