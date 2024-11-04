using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dtos
{
    public class CreateSellerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }


        //Metodo para crear un Seller
        public Seller Toseller()
        {
            return new Seller
            {
                Name = this.Name,
                Surname = this.Surname,
                Email = this.Email,
                UserName = this.UserName,
                Password = this.Password,
                Active = this.Active,
                Role = "Seller"
            };
        }

        //Metodo para actualizar
        public void UpdateSeller(Seller seller)
        {
            seller.Name = this.Name;
            seller.Surname = this.Surname;
            seller.Email = this.Email;
            seller.UserName = this.UserName;
            seller.Password = this.Password;
            seller.Active = this.Active;
        }

        public static CreateSellerDTO FromSeller(Seller seller)
        {
            return new CreateSellerDTO
            {
                Name = seller.Name,
                Surname = seller.Surname,
                Email = seller.Email,
                UserName = seller.UserName,
                Password = seller.Password,
                Active = seller.Active
            };
        }

    }
}
