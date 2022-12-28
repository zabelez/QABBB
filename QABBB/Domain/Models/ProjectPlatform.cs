using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class ProjectPlatform
    {
        public ProjectPlatform()
        {
            Heatmaps = new HashSet<Heatmap>();
        }

        public int IdProjectPlatform { get; set; }
        public int IdProject { get; set; }
        public int IdPlatform { get; set; }
        public int? CohortSize { get; set; }

        public virtual Platform IdPlatformNavigation { get; set; } = null!;
        public virtual Project IdProjectNavigation { get; set; } = null!;
        public virtual ICollection<Heatmap> Heatmaps { get; set; }
    }
}
