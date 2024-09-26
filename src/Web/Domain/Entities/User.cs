using Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    abstract class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public RollUser Roll {  get; set; }

    }
}
