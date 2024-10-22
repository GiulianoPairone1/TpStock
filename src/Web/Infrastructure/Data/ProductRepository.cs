using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository (ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override List<Product> GetAll()
        {
            return _context.Products
                .Include(p => p.ProductStores)
                .ToList();
        }

        public int GetTotalQuantity(int productId)
        {
            return _context.ProductStores
                .Where(ps => ps.ProductId == productId)
                .Sum(ps => ps.Quantity);
        }
    }
}
