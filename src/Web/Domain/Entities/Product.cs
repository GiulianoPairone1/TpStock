using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool Active { get; set; }

    }
}