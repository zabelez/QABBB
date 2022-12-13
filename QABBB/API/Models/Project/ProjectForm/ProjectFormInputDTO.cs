using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.ProjectForm
{
    public class ProjectFormInputDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
