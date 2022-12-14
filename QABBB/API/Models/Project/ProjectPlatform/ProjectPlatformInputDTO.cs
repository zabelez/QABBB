using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.ProjectPlatform
{
    public class ProjectPlatformInputDTO
    {
        [Required]
        public int IdProject { get; set; }
        [Required]
        public int IdGamePlatform { get; set; }
        
    }
}
