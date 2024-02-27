using Application.Dtos.Product;
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
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;

        private readonly IProductRepo _productRepo;

        public ProductService(IMapper mapper, IProductRepo productRepo)
        {
            _mapper = mapper;
            _productRepo = productRepo;
        }

        public async Task<ProductOutgoingDTO> CreateProduct(ProductIncomingDTO product)
        {
            var _product = _mapper.Map<Product>(product);

            var response = await _productRepo.CreateProduct(_product);

            return _mapper.Map<ProductOutgoingDTO>(_product);
            
        }

        public async Task<ProductOutgoingDTO> DeleteProduct(Guid id)
        {
            var existingProduct = await _productRepo.GetProduct(id);
            if (existingProduct != null)
            {
                var response = await _productRepo.DeleteProduct(existingProduct);
            }

            return _mapper.Map<ProductOutgoingDTO>(existingProduct);
        }

        public async Task<ProductOutgoingDTO> GetProduct(Guid id)
        {
            var existingProduct = await _productRepo.GetProduct(id);

            return _mapper.Map<ProductOutgoingDTO>(existingProduct);
        }

        public async Task<List<ProductOutgoingDTO>> GetProducts()
        {
            var allProducts = await _productRepo.GetProducts();

            return _mapper.Map<List<ProductOutgoingDTO>>(allProducts);
        }

        public async Task<ProductOutgoingDTO> UpdateProduct(Guid id, ProductIncomingDTO product)
        {
            var updatedProduct = _mapper.Map<Product>(product);
            var response = await _productRepo.UpdateProduct(id, updatedProduct);

            return _mapper.Map<ProductOutgoingDTO>(response);
        }
    }
}
