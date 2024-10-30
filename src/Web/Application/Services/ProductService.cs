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

        public List<ProductDTO> GetAllByBrand(string brand)
        {
            var products = _productRepository.FindAllByCondition(p => p.Brand == brand && p.Active);

            return products.Select(ProductDTO.FromProduct).ToList();
        }
        public ProductDTO Create(ProductDTO productDto)
        {
            var product = productDto.ToProduct();
            var addedProduct = _productRepository.add(product);
            return ProductDTO.FromProduct(addedProduct);
        }

        public void Update(ProductDTO productDto)
        {
            var product = _productRepository.FindByCondition(p => p.Name == productDto.Name);
            if (product != null)
            {
                productDto.UpdateProduct(product); 
                _productRepository.update(product); 
            }
        }

        public void Delete(string productName) 
        {
            var product = _productRepository.FindByCondition(p => p.Name == productName); 
            if (product != null)
            {
                product.Active = false; 
                _productRepository.update(product); 
            }
        }
    }
}
