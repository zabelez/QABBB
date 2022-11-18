using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class HeatmapLayer
    {
        public int IdHeatmapLayer { get; set; }
        public int IdHeatmap { get; set; }
        public string ImagePath { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual Heatmap IdHeatmapNavigation { get; set; } = null!;
    }
}
