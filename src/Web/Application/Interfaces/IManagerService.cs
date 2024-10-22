using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IManagerService
    {
        List<ManagerDTO> GetAll();
        List<ManagerDTO> GetByName(string name);
        ManagerDTO Create(ManagerDTO managerdto);
        ManagerDTO Update(ManagerDTO managerdto);
        void Delete(string userName);
    }
}
