using Application.Dtos.Cart;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICartService
    {
        public Task<string> AddToCart(CartIncomingDTO data);

        public Task<Cart> GetCart(Guid id);

        public Task<string> CartCheckout(Guid id);
    }
}
