using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Heatmap
    {
        public Heatmap()
        {
            HeatmapLayers = new HashSet<HeatmapLayer>();
        }

        public int IdHeatmap { get; set; }
        public int IdProjectPlatform { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;

        public virtual ProjectPlatform IdProjectPlatformNavigation { get; set; } = null!;
        public virtual ICollection<HeatmapLayer> HeatmapLayers { get; set; }
    }
}
