using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectSummaryDoc
{
    public class ProjectSummaryDocEditDTO
    {
        public int IdProjectSummaryDoc { get; set; }
        public int IdProject { get; set; }
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
