using Domain.Entities;

namespace Application.Models.Dtos
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Name = this.Name,
                Brand = this.Brand,
                Description = this.Description,
                Price = this.Price,
                Active = this.Active
            };
        }

        public void UpdateProduct (Product product)
        {
            product.Name = this.Name;
            product.Brand = this.Brand;
            product.Description = this.Description;
            product.Price = this.Price;
        }

        public static CreateProductDTO FromProduct(Product product)
        {
            return new CreateProductDTO
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
