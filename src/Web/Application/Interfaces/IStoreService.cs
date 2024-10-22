using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStoreService
    {
        List<StoreDTO> GetAll();
        StoreDTO GetById(int id);
        StoreDTO Create(StoreDTO storeDto);
        void Update(StoreDTO storeDto);
        void AddProductToStore(int productId, int storeId, int quantity);
        int GetProductQuantityInStore(int productId, int storeId);
    }
}
