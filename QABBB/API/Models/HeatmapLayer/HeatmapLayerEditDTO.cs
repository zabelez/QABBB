using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.HeatmapLayer{
    public class HeatmapLayerEditDTO
    {
        public int IdHeatmapLayer { get; set; }
        public int IdHeatmap { get; set; }
        public string ImagePath { get; set; } = null!;
        public string Name { get; set; } = null!;
        
    }
}
