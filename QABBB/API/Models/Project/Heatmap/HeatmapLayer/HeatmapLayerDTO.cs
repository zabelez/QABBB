using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.Heatmap.HeatmapLayer
{
    public class HeatmapLayerDTO
    {
        public int IdHeatmapLayer { get; set; }
        public int IdHeatmap { get; set; }
        public string ImagePath { get; set; } = null!;
        public string Name { get; set; } = null!;
        
    }
}
