using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Game.Platform
{
    public class GamePlatformInputDTO
    {
        [Required]
        public int IdGame { get; set; }
        [Required]
        public int IdPlatform { get; set; }
        
    }
}