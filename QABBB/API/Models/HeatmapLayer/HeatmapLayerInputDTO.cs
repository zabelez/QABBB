using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.HeatmapLayer{
    public class HeatmapLayerInputDTO
    {
        public int IdHeatmap { get; set; }
        public string ImagePath { get; set; } = null!;
        public string Name { get; set; } = null!;
        
    }
}
