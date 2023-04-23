using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectInterview
{
    public class ProjectInterviewInputDTOForPutProject
    {
        public int IdProjectInterview { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Url { get; set; }
    }
}