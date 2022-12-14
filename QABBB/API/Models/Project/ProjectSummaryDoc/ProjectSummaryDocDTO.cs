using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.ProjectSummary
{
    public class ProjectSummaryDocDTO
    {
        public int IdProjectSummaryDoc { get; set; }
        public int IdProject { get; set; }
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
