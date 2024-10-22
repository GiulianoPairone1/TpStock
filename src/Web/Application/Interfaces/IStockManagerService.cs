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
        List<StockManagerDTO> GetAll();
        List<StockManagerDTO> GetByName(string name);
        StockManagerDTO Create(StockManagerDTO stockmanagerdto);
        StockManagerDTO Update(StockManagerDTO stockmanagerdto);
        void Delete(string userName);
    }
}
