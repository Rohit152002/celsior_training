using PizzaWebApi.Models.DTOs;
using System.Data;

namespace PizzaWebApi.Interfaces
{
    public interface ICartService
    {
        public Task<PizzaCartDTO> AddPizzaToCart(PizzaCartDTO pizzaCartDTO, int customerId);
        public Task<CartDTO> GetCart(int customerId);
        public Task<CartDTO> UpdateCart(int cardNumber, PizzaCartDTO pizzaCartDTO);
    }
}
