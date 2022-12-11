using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Platform
{
    public class PlatformEditInputDTO
    {
        [Required]
        public int IdPlatform { get; set; }
        [Required]
        public string Name { get; set; } = "";

    }
}