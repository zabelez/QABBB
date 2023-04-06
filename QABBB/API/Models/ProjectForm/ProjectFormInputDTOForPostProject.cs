using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectForm
{
    public class ProjectFormInputDTOForPostProject
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Url { get; set; }
        
    }
}
