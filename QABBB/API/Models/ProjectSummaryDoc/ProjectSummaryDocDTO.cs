using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectSummaryDoc
{
    public class ProjectSummaryDocDTO
    {
        public int IdProjectSummaryDoc { get; set; }
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
