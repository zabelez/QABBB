using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.Heatmap
{
    public class HeatmapDTO
    {
        public int IdHeatmap { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        
        
    }
}
