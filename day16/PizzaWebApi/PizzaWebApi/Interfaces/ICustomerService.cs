using PizzaWebApi.Models;

namespace PizzaWebApi.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Pizza>> ViewPizzas();

    }
}
