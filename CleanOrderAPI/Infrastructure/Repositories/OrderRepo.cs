using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private static List<Order> Orders = new List<Order>();

        public Task<string> CreateOrder(Order order)
        {
            Orders.Add(order);

            return Task.FromResult("Order Received !");

        }

        public Task<List<Order>> GetOrders(Guid id)
        {
            var orders = Orders.FindAll(x => x.UserId == id);

            return Task.FromResult(orders);
        }
    }
}
