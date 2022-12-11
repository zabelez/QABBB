using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.User
{
    public class ResetPasswordDTO
    {
        [Required]
        public string? OldPassword { get; set; }
        [Required]
        public string? NewPassword { get; set; }

    }
}

