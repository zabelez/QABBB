using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.ProjectPlatform
{
    public class ProjectPlatformDTO
    {
        public int IdProjectPlatform { get; set; }
        public int IdProject { get; set; }
        public int IdGamePlatform { get; set; }
        
    }
}
