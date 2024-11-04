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
        List<CreateStoreDTO> GetAll();
        CreateStoreDTO GetById(int id);
        CreateStoreDTO Create(CreateStoreDTO storeDto);
        void Update(CreateStoreDTO storeDto);
        void DesactivateStoreByName(string name);
    }
}
