using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    internal class Store
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public TypeStore TypeStorare { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }
    }
}
