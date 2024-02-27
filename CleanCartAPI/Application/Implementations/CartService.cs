using Application.Dtos.Cart;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Implementations
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;

        private readonly ICartRepo _cartRepo;

        public CartService(IMapper mapper, ICartRepo cartRepo)
        {
            _mapper = mapper;
            _cartRepo = cartRepo;
        }

        public async Task<string> AddToCart(CartIncomingDTO data)
        {
            try
            {
                var existingCart = await _cartRepo.GetCart(data.UserId);

                var response = await _cartRepo.AddToCart(data.UserId, data.ProductId);
                return response;
            }
            catch (Exception)
            {
                var newCart = _mapper.Map<Cart>(data);
                var response = await _cartRepo.CreateCart(newCart);
                return response;

            }

        }

        public async Task<Cart> GetCart(Guid id)
        {
            var existingCart = await _cartRepo.GetCart(id);
            return existingCart;
        }

        public async Task<string> CartCheckout(Guid id)
        {
            var existingCart = await _cartRepo.GetCart(id);

            if (existingCart != null)
            {
                var response = await _cartRepo.CartCheckout(id);
                return response;
            }
            else
            {
                return ("There is nothing is cart to order !");
            }

        }

    }
}
