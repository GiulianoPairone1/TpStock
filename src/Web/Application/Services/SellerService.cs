using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerrepository;

        public SellerService(ISellerRepository sellerrepository)
        {
            _sellerrepository = sellerrepository;
        }

        public List<SellerDTO> GetAll()
        {
            return _sellerrepository.GetAll()
                .Select(seller => new SellerDTO
                {
                    Name = seller.Name,
                    UserName = seller.UserName,
                    Email = seller.Email
                })
                .ToList();
        }
        public SellerDTO GetByName(string name)
        {
            var seller = _sellerrepository.FindByCondition(p => p.Name == name && p.Active);

            if (seller == null)
            {
                return null;
            }

            return new SellerDTO
            {
                Name = seller.Name,
                UserName = seller.UserName,
                Email = seller.Email,
            };
        }
        public SellerDTO Create(SellerDTO sellerDto)
        {
            var seller = sellerDto.Toseller();
            var addedSeller= _sellerrepository.add(seller);
            return SellerDTO.FromSeller(addedSeller);
        }
        public SellerDTO Update(SellerDTO sellerDTO)
        {
            var SearchSeller = _sellerrepository.GetAll().FirstOrDefault(s => s.UserName == sellerDTO.UserName);

            if (SearchSeller == null)
            {
                throw new Exception("Vendedor no encontrado");
            }

            sellerDTO.UpdateSeller(SearchSeller);
            var updateSeller = _sellerrepository.update(SearchSeller);
            return SellerDTO.FromSeller(updateSeller);
        }
        public void Delete(string userName)
        {
            var seller = _sellerrepository.GetAll().FirstOrDefault(s => s.UserName == userName);
            if (seller == null)
            {
                throw new Exception("Vendedor no encontrado");
            }

            seller.Active = false;
            _sellerrepository.update(seller);
        }
    }
}
