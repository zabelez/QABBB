using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.ProjectFile
{
    public class ProjectFileInputDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
