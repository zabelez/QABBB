using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectFile
{
    public class ProjectFileInputDTOForPostProject
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Url { get; set; }
        
    }
}
