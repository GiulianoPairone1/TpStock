using System.ComponentModel.DataAnnotations;
namespace TpStock.Data.Models
{
    public class CredentialsDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}