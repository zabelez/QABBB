using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectForm
{
    public class ProjectFormInputDTOForPutProject
    {
        public int IdProjectForm { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Url { get; set; }
        
    }
}
