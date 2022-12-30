using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectSummaryDoc
{
    public class ProjectSummaryDocInputDTO
    {
        [Required]
        public int IdProject { get; set; }
        [Required]
        public string Label { get; set; } = null!;
        [Required]
        public string Url { get; set; } = null!;
        
    }
}
