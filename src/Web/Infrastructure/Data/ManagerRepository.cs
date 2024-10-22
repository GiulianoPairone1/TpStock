using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ManagerRepository: RepositoryBase<Manager> , IManagerRepository
    {
        public ManagerRepository(ApplicationDbContext context) : base(context) { }
    }
}
