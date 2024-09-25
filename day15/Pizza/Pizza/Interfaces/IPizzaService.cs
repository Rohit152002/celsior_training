using PizzaApplication.Models.ViewModel;

namespace PizzaApplication.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaImageViewModel> GetAllPizzas();
    }
}
