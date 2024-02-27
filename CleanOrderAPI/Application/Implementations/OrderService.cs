using Application.Dtos.Order;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;

        private readonly IOrderRepo _orderRepo;

        public OrderService(IMapper mapper, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        public async Task<string> CreateOrder(OrderIncomingDTO order)
        {
            var newOrder = _mapper.Map<Order>(order);

            if (newOrder != null)
            {
                var response = await _orderRepo.CreateOrder(newOrder);
                return response;
            }
            else
            {
                throw new Exception("Something Went Wrong !");
            }
        }

        public async Task<List<Order>> GetOrders(Guid id)
        {
            var orders = await _orderRepo.GetOrders(id);

            return orders;
        }
    }
}
