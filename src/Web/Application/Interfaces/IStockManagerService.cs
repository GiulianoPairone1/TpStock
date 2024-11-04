using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStockManagerService
    {
        List<CreateStockManagerDTO> GetAll();
        CreateStockManagerDTO GetByName(string name);
        CreateStockManagerDTO Create(CreateStockManagerDTO stockmanagerdto);
        CreateStockManagerDTO Update(CreateStockManagerDTO stockmanagerdto);
        void Delete(string userName);
    }
}
