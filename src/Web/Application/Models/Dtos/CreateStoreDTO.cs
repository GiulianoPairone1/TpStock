using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class CreateStoreDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }

        public static CreateStoreDTO FromStore(Store store)
        {
            return new CreateStoreDTO
            {
                Name = store.Name,
                Description = store.Description,
                Address = store.Address,
                City = store.City,
                Active=store.Active,
            };
        }

        public Store ToStore()
        {
            return new Store
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                City = this.City
            };
        }

        public void UpdateStore(Store store)
        {
            store.Description = this.Description;
            store.Address = this.Address;
            store.City = this.City;
        }
    }
}
