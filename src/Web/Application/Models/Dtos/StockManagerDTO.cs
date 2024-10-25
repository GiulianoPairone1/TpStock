using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class StockManagerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public StockManager ToManagerStock()
        {
            return new StockManager
            {
                Name = this.Name,
                Surname = this.Surname,
                Email = this.Email,
                UserName = this.UserName,
                Password = this.Password,
                Active = this.Active,
                Role = "StockManager"
            };
        }

        public void UpdateStockManager(StockManager stockManager)
        {
            stockManager.Name = this.Name;
            stockManager.Surname = this.Surname;
            stockManager.Email = this.Email;
            stockManager.UserName = this.UserName;
            stockManager.Password = this.Password;
        }

        public static StockManagerDTO FromStockManager(StockManager stockManager)
        {
            return new StockManagerDTO
            {
                Name = stockManager.Name,
                Surname = stockManager.Surname,
                Email = stockManager.Email,
                UserName = stockManager.UserName,
                Password = stockManager.Password,
                Active = stockManager.Active
            };
        }
    }
}
