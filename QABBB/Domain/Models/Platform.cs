using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Platform
    {
        public Platform()
        {
            GamePlatforms = new HashSet<GamePlatform>();
            UserPlatforms = new HashSet<UserPlatform>();
        }

        public int IdPlatform { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<GamePlatform> GamePlatforms { get; set; }
        public virtual ICollection<UserPlatform> UserPlatforms { get; set; }
    }
}
