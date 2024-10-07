using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    internal class StoreDTO
    {
        public string Name { get; set; }
        public TypeStore TypeStorare { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
