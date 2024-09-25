using PizzaWebApi.Exceptions;
using PizzaWebApi.Interfaces;
using PizzaWebApi.Models;

namespace PizzaWebApi.Repository
{
    public class OrderDetailsRepository:IRepository<int,OrderDetails>
    {
        List<OrderDetails> orderDetails = new List<OrderDetails>();
        public async Task<OrderDetails> Add(OrderDetails entity)
        {
            entity.OrderNumber = orderDetails.Max(o => o.OrderNumber) + 1;
            orderDetails.Add(entity);
            return entity;
        }

        public async Task<OrderDetails> Delete(int key)
        {
            var order = await Get(key);
            orderDetails.Remove(order);
            return order;
        }

        public async Task<OrderDetails> Get(int key)
        {
            var order = orderDetails.FirstOrDefault(c => c.OrderNumber == key);
            if (order == null)
            {
                throw new NoEntityFoundException("Pizza", key);
            }
            return order;
        }

        public async Task<IEnumerable<OrderDetails>> GetAll()
        {
            if (orderDetails.Count == 0)
            {
                throw new CollectionEmptyException("Pizza");
            }
            return orderDetails;
        }

        public async Task<OrderDetails> Update(OrderDetails entity)
        {
            var order = await Get(entity.OrderNumber);

            if (order == null)
            {
                throw new NoEntityFoundException("Pizza", entity.OrderNumber);
            }
            order.OrderNumber = entity.OrderNumber;
           order.Quantity = entity.Quantity;
            order.PizzaId = entity.PizzaId;
            return order;
        }
    }
}
