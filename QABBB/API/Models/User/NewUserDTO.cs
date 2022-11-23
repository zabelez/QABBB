using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.User
{
    public class NewUserDTO
    {
        [Required]
        public string PersonName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool IsDarkMode { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        //public int IdPublisher {get; set; }

        //public int IdDeveloper {get; set;}

    }
}

