using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectFile
{
    public class ProjectFileInputDTOForPutProject
    {
        public int IdProjectFile { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Url { get; set; }
        
    }
}
