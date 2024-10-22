using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StockManagerRepository : RepositoryBase<StockManager> , IStockManagerRepository
    {
        public StockManagerRepository(ApplicationDbContext context ):base(context)
        { }
    }
}
