using Application.Dtos.Product;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private static List<Product> products = new List<Product>();

        public Task<Product> CreateProduct(Product product)
        {

            products.Add(product);

            return Task.FromResult(product);

        }

        public Task<Product> DeleteProduct(Product product)
        {

            products.Remove(product);

            return Task.FromResult(product);
        }

        public Task<Product> GetProduct(Guid id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new Exception($"Product with id {id} was not found.");
            }

            return Task.FromResult(product);
        }

        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(products);
        }

        public async Task<Product> UpdateProduct(Guid id, Product updatedProduct)
        {
            var existingProduct = await GetProduct(id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Quantity = updatedProduct.Quantity;

                return existingProduct;

            }

            throw new Exception($"Product with id {id} was not found.");

        }
    }
}
