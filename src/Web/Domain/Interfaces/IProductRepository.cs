using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        int GetTotalQuantity(int productId);
        List<Product> FindAllByCondition(Func<Product, bool> condition);

    }
}
