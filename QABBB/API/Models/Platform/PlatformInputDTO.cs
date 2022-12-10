using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Platform
{
    public class PlatformInputDTO
    {
        [Required]
        public string Name { get; set; }

    }
}