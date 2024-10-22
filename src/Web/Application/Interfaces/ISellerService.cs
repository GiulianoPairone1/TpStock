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
        SellerDTO Create(SellerDTO sellerdto);
        List<SellerDTO> GetByName(string name);
        List<SellerDTO> GetAll();
        SellerDTO Update(SellerDTO sellerDTO);
        void Delete(string userName);
    }
}
