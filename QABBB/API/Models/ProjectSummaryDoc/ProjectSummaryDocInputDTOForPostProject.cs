using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectSummaryDoc
{
    public class ProjectSummaryDocInputDTOForPostProject
    {
        [Required]
        public string? Label { get; set; }
        [Required]
        public string? Url { get; set; }
        
    }
}
