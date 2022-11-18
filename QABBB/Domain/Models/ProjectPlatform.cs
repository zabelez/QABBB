using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class ProjectPlatform
    {
        public int IdProjectPlatform { get; set; }
        public int IdProject { get; set; }
        public int IdGamePlatform { get; set; }

        public virtual GamePlatform IdGamePlatformNavigation { get; set; } = null!;
        public virtual Project IdProjectNavigation { get; set; } = null!;
    }
}
