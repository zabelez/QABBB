using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectFile
{
    public class ProjectFileEditDTO
    {
        public int IdProjectFile { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
