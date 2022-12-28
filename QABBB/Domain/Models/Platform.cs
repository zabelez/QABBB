using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Platform
    {
        public Platform()
        {
            ProjectPlatforms = new HashSet<ProjectPlatform>();
            UserPlatforms = new HashSet<UserPlatform>();
        }

        public int IdPlatform { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProjectPlatform> ProjectPlatforms { get; set; }
        public virtual ICollection<UserPlatform> UserPlatforms { get; set; }
    }
}
