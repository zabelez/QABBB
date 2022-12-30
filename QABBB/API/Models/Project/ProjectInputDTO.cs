using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project
{
    public class ProjectInputDTO
    {
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public DateTime StartDateTime { get; set; }
        public int? Duration { get; set; }
        public string? PowerBiUrl { get; set; }
        public string? SpreadsheetUrl { get; set; }
        
    }
}
