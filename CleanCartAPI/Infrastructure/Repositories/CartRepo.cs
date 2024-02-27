using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories
{
    public class CartRepo : ICartRepo
    {
        private static List<Cart> Carts = new List<Cart>();

        public Task<string> CreateCart(Cart data)
        {
            Carts.Add(data);

            return Task.FromResult("Cart Created.");
        }

        public Task<string> AddToCart(Guid userId, Guid productId)
        {
            var existingCart = Carts.FirstOrDefault(x => x.UserId == userId);
            if (existingCart != null)
            {
                existingCart.Products.Add(productId);
            }

            return Task.FromResult("Item added to cart !");

        }

        public Task<Cart> GetCart(Guid id)
        {
            var existingCart = Carts.FirstOrDefault(x => x.UserId == id);

            if (existingCart == null)
            {
                throw new Exception("Not Found");
            }

            else
            {
                return Task.FromResult(existingCart);
            }
        }

        public Task<string> CartCheckout(Guid id)
        {
            var existingCart = Carts.FirstOrDefault(x => x.UserId == id);

            if (existingCart != null)
            {
                existingCart.Products.Clear();
            }

            return Task.FromResult("Cart is empty !");
        }
    }
}
