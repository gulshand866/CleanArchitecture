using Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductOutgoingDTO>> GetProducts();
        public Task<ProductOutgoingDTO> GetProduct(Guid id);
        public Task<ProductOutgoingDTO> CreateProduct(ProductIncomingDTO product);
        public Task<ProductOutgoingDTO> UpdateProduct(Guid id, ProductIncomingDTO product);
        public Task<ProductOutgoingDTO> DeleteProduct(Guid id);
    }
}
