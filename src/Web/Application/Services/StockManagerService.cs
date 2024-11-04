using Application.Interfaces;
using Application.Models.Dtos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StockManagerService : IStockManagerService
    {
        private readonly IStockManagerRepository _stockManagerRepository;
        public StockManagerService(IStockManagerRepository stockManagerRepository)
        {
            _stockManagerRepository = stockManagerRepository;
        }

        public List<CreateStockManagerDTO> GetAll()
        {
            return _stockManagerRepository.GetAll()
                .Select(stockManager => new CreateStockManagerDTO
                {
                    Name = stockManager.Name,
                    UserName = stockManager.UserName,
                    Email = stockManager.Email,
                }).ToList();
        }

        public CreateStockManagerDTO GetByName(string name)
        {
            var stockmanager = _stockManagerRepository.FindByCondition(p => p.Name == name && p.Active);

            if (stockmanager == null)
            {
                return null;
            }

            return new CreateStockManagerDTO
            {
                Name = stockmanager.Name,
                UserName = stockmanager.UserName,
                Email = stockmanager.Email,
            };
        }

        public CreateStockManagerDTO Create(CreateStockManagerDTO stockmanagerdto)
        {
            var stockmanager = stockmanagerdto.ToManagerStock();
            var addstockmanager = _stockManagerRepository.add(stockmanager);
            return CreateStockManagerDTO.FromStockManager(addstockmanager);
        }

        public CreateStockManagerDTO Update(CreateStockManagerDTO stockmanagerdto)
        {
            var SearchstockManager = _stockManagerRepository.GetAll().FirstOrDefault(s => s.UserName == stockmanagerdto.UserName);

            if (SearchstockManager == null)
            {
                throw new Exception("Encargo de Stock no encontrado");
            }

            stockmanagerdto.UpdateStockManager(SearchstockManager);
            var stockManager = _stockManagerRepository.update(SearchstockManager);
            return CreateStockManagerDTO.FromStockManager(stockManager);
        }

        public void Delete(string userName)
        {
            var stockManager = _stockManagerRepository.GetAll().FirstOrDefault(s => s.UserName == userName);
            if (stockManager == null)
            {
                throw new Exception("Encargo de Stock no encontrado");
            }

            stockManager.Active = false;
            _stockManagerRepository.update(stockManager);
        }


    }
}
