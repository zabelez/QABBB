using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Game
    {
        public Game()
        {
            GamePlatforms = new HashSet<GamePlatform>();
        }

        public int IdGame { get; set; }
        public int IdPublisher { get; set; }
        public int IdDeveloper { get; set; }
        public string Name { get; set; } = null!;
        public string? Gamelogo { get; set; }

        public virtual Developer IdDeveloperNavigation { get; set; } = null!;
        public virtual Publisher IdPublisherNavigation { get; set; } = null!;
        public virtual ICollection<GamePlatform> GamePlatforms { get; set; }
    }
}
