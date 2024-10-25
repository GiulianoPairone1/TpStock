using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository: RepositoryBase<User>,IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context ):base(context) 
        {
            _context = context;
        }

        public User? GetUserByUserName(string UserName)
        {
            return _context.Users.SingleOrDefault(p=>p.UserName == UserName);
        }
    }
}
