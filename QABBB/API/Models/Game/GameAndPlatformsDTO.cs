using System;
using QABBB.API.Models.Game.Platform;
using QABBB.Models;

namespace QABBB.API.Models.Game
{
    public class GameAndPlatformsDTO
    {
        public int IdGame { get; set; }
        public string Name { get; set; } = null!;
        public string? Gamelogo { get; set; }
        public int IdPublisher { get; set; }
        public string? Publisher { get; set;}
        public int IdDeveloper { get; set; }
        public string? Developer {get; set;}

        public List<GamePlatformDTO>? Platforms {get; set;}

    }
}

