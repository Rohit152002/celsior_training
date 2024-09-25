using UnderstandingStructure.Interfaces;
using UnderstandingStructure.Models;

namespace UnderstandingStructure.Services
{
    public class PizzaService : IPizzaService
    {

        private readonly IRepository<int ,Pizza> _repository;


        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        public List<Pizza> GetAllPizzas()
        {
            var pizzas = _repository.GetAll();
            for (int i=0; i<pizzas.Count; i++)
            {
                pizzas[i].Image="/images"+pizzas[i].Image;
            }
            return pizzas;
        }
    }
}
