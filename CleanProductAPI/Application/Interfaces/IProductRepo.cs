using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProduct(Guid id);
        public Task<Product> CreateProduct(Product product);
        public Task<Product> UpdateProduct(Guid id, Product product);
        public Task<Product> DeleteProduct(Product product);
    }
}
