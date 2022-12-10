using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.User.Platform
{
    public class UserPlatformInputDTO
    {
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int IdPlatform { get; set; }
        
    }
}