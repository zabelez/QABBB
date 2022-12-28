using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Heatmap{
    public class HeatmapDTO
    {
        public int IdHeatmap { get; set; }
        public int IdProjectPlatform { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        
        
    }
}
