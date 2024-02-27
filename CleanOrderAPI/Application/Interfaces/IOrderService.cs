using Application.Dtos.Order;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        public Task<string> CreateOrder(OrderIncomingDTO order);

        public Task<List<Order>> GetOrders(Guid id);
    }
}
