using System.ComponentModel.DataAnnotations;

namespace _1st_Project_Api.Dtos.Account
{
    public class LoginDto
    {
        [Required]

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
