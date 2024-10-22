using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class ManagerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }


        public Manager ToManager()
        {
            return new Manager
            {
                Name = this.Name,
                Surname = this.Surname,
                Email = this.Email,
                UserName = this.UserName,
                Password = this.Password,
                Active = this.Active,
            };
        }

        public void UpdateManager(Manager manager)
        {
            manager.Name = this.Name;
            manager.Surname = this.Surname;
            manager.Email = this.Email;
            manager.UserName = this.UserName;
            manager.Password = this.Password;
            manager.Active = this.Active;
        }

        public static ManagerDTO FromManager(Manager manger)
        {
            return new ManagerDTO
            {
                Name = manger.Name,
                Surname = manger.Surname,
                Email = manger.Email,
                UserName = manger.UserName,
                Password = manger.Password,
                Active = manger.Active,
            };
        }
    }
}
