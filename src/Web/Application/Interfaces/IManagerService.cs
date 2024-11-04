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
        List<CreateManagerDTO> GetAll();
        CreateManagerDTO GetByName(string name);
        CreateManagerDTO Create(CreateManagerDTO managerdto);
        CreateManagerDTO Update(CreateManagerDTO managerdto);
        void Delete(string userName);
    }
}
