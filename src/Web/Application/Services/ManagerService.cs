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
    public class ManagerService: IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService (IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public List<ManagerDTO> GetAll()
        {
            return _managerRepository.GetAll()
                .Select(manager => new ManagerDTO
                {
                    Name = manager.Name,
                    UserName = manager.UserName,
                    Email = manager.Email,
                }).ToList();
        }

        public ManagerDTO GetByName(string name)
        {
            var manager = _managerRepository.FindByCondition(p => p.Name == name && p.Active);

            if (manager == null)
            {
                return null;
            }

            return new ManagerDTO
            {
                Name = manager.Name,
                UserName = manager.UserName,
                Email = manager.Email,
            };
        }

        public ManagerDTO Create(ManagerDTO managerdto)
        {
            var manager = managerdto.ToManager();
            var addmanager=_managerRepository.add(manager);
            return ManagerDTO.FromManager(addmanager);
        }

        public ManagerDTO Update(ManagerDTO managerdto)
        {
            var SearchManagaer = _managerRepository.GetAll().FirstOrDefault(s => s.UserName == managerdto.UserName);
            if (SearchManagaer == null)
            {
                throw new Exception("Gerente no encontrado");
            }
            managerdto.UpdateManager(SearchManagaer);
            var uddateManager = _managerRepository.update(SearchManagaer);
            return ManagerDTO.FromManager(uddateManager);
        }

        public void Delete(string userName)
        {
            var manager = _managerRepository.GetAll().FirstOrDefault(m => m.UserName == userName);
            if (manager == null)
            {
                throw new Exception("Gerente no encontrado");
            }
            manager.Active = false;
            _managerRepository.update(manager);
        }

    }
}
