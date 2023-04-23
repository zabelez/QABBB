using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectInterview
{
    public class ProjectInterviewInputDTO
    {
        [Required]
        public int IdProject { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Url { get; set; } = null!;
        
    }
}
