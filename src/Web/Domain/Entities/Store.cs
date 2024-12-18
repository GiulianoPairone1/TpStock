﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }
        public ICollection<ProductStore> ProductStores { get; set; }
        [Required]
        public bool Active { get; set; } = true;

        public Store()
        {
            ProductStores=new List<ProductStore>();
        }

    }
}
