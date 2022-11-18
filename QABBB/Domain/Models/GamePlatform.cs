using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class GamePlatform
    {
        public GamePlatform()
        {
            ProjectPlatforms = new HashSet<ProjectPlatform>();
        }

        public int IdGamePlatform { get; set; }
        public int IdGame { get; set; }
        public int IdPlatform { get; set; }

        public virtual Game IdGameNavigation { get; set; } = null!;
        public virtual Platform IdPlatformNavigation { get; set; } = null!;
        public virtual ICollection<ProjectPlatform> ProjectPlatforms { get; set; }
    }
}
