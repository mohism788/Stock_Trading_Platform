﻿using System.ComponentModel.DataAnnotations;

namespace _1st_Project_Api.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username{ get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password{ get; set; }    
    }
}
