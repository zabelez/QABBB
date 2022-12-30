using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectFile
{
    public class ProjectFileDTO
    {
        public int IdProjectFile { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
        
    }
}
