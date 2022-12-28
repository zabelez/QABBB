using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Heatmap{
    public class HeatmapEditDTO
    {
        public int IdHeatmap { get; set; }
        public int IdGameProject { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        
    }
}
