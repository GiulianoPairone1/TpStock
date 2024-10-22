using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductStoreRepository : RepositoryBase<ProductStore>, IProductStoreRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductStoreRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
