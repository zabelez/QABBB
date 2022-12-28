using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectForm
{
    public class ProjectFormEditDTO
    {
        public int IdProjectForm { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
