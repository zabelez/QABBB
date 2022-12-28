using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectSummaryDoc
{
    public class ProjectSummaryDocInputDTO
    {
        public int IdProject { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        
    }
}
