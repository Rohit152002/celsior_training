﻿using PizzaWebApi.Exceptions;
using PizzaWebApi.Interfaces;
using PizzaWebApi.Models;

namespace PizzaWebApi.Repository
{
    public class OrderRepository : IRepository<int, Order>
    {
        List<Order> orders = new List<Order>();
        public async Task<Order> Add(Order entity)
        {
            entity.OrderNumber=orders.Max(o => o.OrderNumber)+1;
            orders.Add(entity);
            return entity;
        }

        public async Task<Order> Delete(int key)
        {
            var order = await Get(key);
            orders.Remove(order);
            return order;
        }

        public async Task<Order> Get(int key)
        {
            var order = orders.FirstOrDefault(c => c.OrderNumber == key);
            if (order == null)
            {
                throw new NoEntityFoundException("Pizza", key);
            }
            return order;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            if (orders.Count == 0)
            {
                throw new CollectionEmptyException("Pizza");
            }
            return orders;
        }

        public async Task<Order> Update(Order entity)
        {
            var order = await Get(entity.OrderNumber);

            if (order == null)
            {
                throw new NoEntityFoundException("Pizza", entity.OrderNumber);
            }
            order.OrderNumber = entity.OrderNumber;
            order.PaymentMethod = entity.PaymentMethod;
            order.OrderStatus = entity.OrderStatus;
            order.CustomerId = entity.CustomerId;
            return order;
        }
    }
}