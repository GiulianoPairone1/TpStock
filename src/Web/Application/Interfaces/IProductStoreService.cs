using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductStoreService
    {
        int GetProductQuantityInStore(int productId, int storeId);
        void AddProductToStore(int productId, int storeId, int quantity);
        void UpdateProductInStore(int productId, int currentStoreId, int? newStoreId, int newQuantity);
    }
}
