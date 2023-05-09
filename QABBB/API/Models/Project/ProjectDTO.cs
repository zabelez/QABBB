using QABBB.API.Models.Company;
using QABBB.API.Models.ProjectPlatform;

namespace QABBB.API.Models.Project
{
    public class ProjectDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; } = null!;
        public DateTime? StartDateTime { get; set; }
        public decimal? Duration { get; set; }
        public List<CompanyDTO> Developers { get; set; } = new List<CompanyDTO>()!;
        public List<CompanyDTO> Publishers { get; set; } = new List<CompanyDTO>()!;
        public List<ProjectPlatformDTO> ProjectPlatforms {get; set; } = new List<ProjectPlatformDTO>()!;

        
    }

}
