using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectInterview
{
    public class ProjectInterviewDTO
    {
        public int IdProjectInterview { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
        
    }
}
