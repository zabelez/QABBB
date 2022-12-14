using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.ProjectFile
{
    public class ProjectFileInputDTO
    {
        [Required]
        public int IdProject { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        
    }
}
