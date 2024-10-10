
using Domain.Enums;

namespace Application.Models
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
    }
}
