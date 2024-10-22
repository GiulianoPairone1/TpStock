using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDTO Create(ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Description = productDto.Description,
                Price = productDto.Price,
                Active = productDto.Active,
            };

            var addProduct= _productRepository.add(product);

            return new ProductDTO
            {
                Name = addProduct.Name,
                Brand = addProduct.Brand,
                Description = addProduct.Description,
                Price = addProduct.Price,
                Active = addProduct.Active
            };

        }

        public List<ProductDTO> GetAll()
        {
            return _productRepository.GetAll()
                .Select(product => new ProductDTO
                {
                    Name = product.Name,
                    Brand = product.Brand,
                    Description = product.Description,
                    Price = product.Price,
                    Active = product.Active
                }).ToList();
        }

    }
}
