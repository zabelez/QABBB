using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.User
{
    public class EditUserDTO
    {
        [Required]
        public int IdPerson { get; set;}

        [Required]
        public string PersonName { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public bool IsDarkMode { get; set; }

        [Required]
        public string Status {get; set;} = "";

    }
}

