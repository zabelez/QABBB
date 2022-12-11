using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.User
{
    public class LoginINDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        
    }
}
