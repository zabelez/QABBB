using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectSummaryDoc
{
    public class ProjectSummaryDocInputDTOForPutProject
    {
        public int IdProjectSummaryDoc { get; set; }
        public string? Label { get; set; }
        public string? Url { get; set; }
        
    }
}
