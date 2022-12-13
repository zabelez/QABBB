using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project
{
    public class ProjectEditDTO
    {
        public int IdProject { get; set; }
        public DateTime StartDateTime { get; set; }
        public string? PowerBiUrl { get; set; }
        public int? Duration { get; set; }
        public string Name { get; set; } = null!;
        public int? CohortSize { get; set; }
        public string? SpreadsheetUrl { get; set; }
        
    }
}
