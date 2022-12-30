using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectForm
{
    public class ProjectFormDTO
    {
        public int IdProjectForm { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
