using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.User
{
    public class LoginINDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
