using PizzaWebApi.Exceptions;
using PizzaWebApi.Interfaces;
using PizzaWebApi.Models;

namespace PizzaWebApi.Repository
{
    public class CartRepository : IRepository<int, Cart>
    {

        List<Cart> Carts = new List<Cart>();

        public async Task<Cart> Add(Cart entity)
        {
            entity.CartNumber = Carts.Max(c => c.CartNumber) + 1;
            Carts.Add(entity);
            return entity;
        }

        public async Task<Cart> Delete(int key)
        {
            var cart = await Get(key);
            Carts.Remove(cart);
            return cart;
        }

        public async Task<Cart> Get(int key)
        {
            var cart = Carts.FirstOrDefault(c => c.CartNumber == key);
            if (cart == null)
            {
                throw new NoEntityFoundException("Cart", key);
            }
            return cart;
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            if (Carts.Count == 0)
            {
                throw new CollectionEmptyException("Customer");
            }
            return Carts;
        }

        public async Task<Cart> Update(Cart entity)
        {
            var cart = await Get(entity.CartNumber);

            if (cart == null)
            {
                throw new NoEntityFoundException("Customer", entity.CustomerId);
            }
            cart.Pizzas = new List<Pizza>(entity.Pizzas);
            return cart;
        }
    }
}
