using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public int TotalQuantity { get; set; }


        public static ProductDTO FromProduct(Product product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
                Active = product.Active
            };
        }

    }
}
