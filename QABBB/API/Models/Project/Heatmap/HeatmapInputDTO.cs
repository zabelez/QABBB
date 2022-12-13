using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.Heatmap
{
    public class HeatmapInputDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
    }
}
