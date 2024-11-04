using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISellerService
    {
        CreateSellerDTO Create(CreateSellerDTO sellerdto);
        CreateSellerDTO GetByName(string name);
        List<CreateSellerDTO> GetAll();
        CreateSellerDTO Update(CreateSellerDTO sellerDTO);
        void Delete(string userName);
    }
}
