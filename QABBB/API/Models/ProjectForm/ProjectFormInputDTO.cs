using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectForm
{
    public class ProjectFormInputDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = ""!;
        public string Url { get; set; } = ""!;
        
    }
}
