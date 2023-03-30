using System;
using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.Company.Employee;

namespace QABBB.API.Models.User
{
    public class NewUserDTO
    {
        [Required]
        public string? PersonName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public bool IsDarkMode { get; set; }
        public List<String> roles {get; set; } = new List<String>()!;
        public List<CompanyEmployeeInputForPostUser> employers {get; set; } = new List<CompanyEmployeeInputForPostUser>()!;
    }
}

