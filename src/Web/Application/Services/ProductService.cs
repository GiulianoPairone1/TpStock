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

        public List<ProductDTO> GetAll()
        {
            return _productRepository.GetAll()
                .Select(product => new ProductDTO
                {
                    Name = product.Name,
                    Brand = product.Brand,
                }).ToList();
        }

        public ProductDTO GetByName(string name)
        {
            var product = _productRepository.FindByCondition(p => p.Name == name && p.Active);

            if (product == null)
            {
                return null; 
            }

            var totalQuantity = _productRepository.GetTotalQuantity(product.Id);

            return new ProductDTO
            {
                Name = product.Name,
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
                Active = product.Active,
                TotalQuantity = totalQuantity
            };
        }

        public ProductDTO Create(ProductDTO productDto)
        {
            var product = productDto.ToProduct();
            var addedProduct = _productRepository.add(product);
            return ProductDTO.FromProduct(addedProduct);
        }

    }
}
