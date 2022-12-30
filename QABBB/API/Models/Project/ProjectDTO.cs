using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.Company;
using QABBB.API.Models.Platform;
using QABBB.API.Models.ProjectFile;
using QABBB.API.Models.ProjectForm;
using QABBB.API.Models.Heatmap;
using QABBB.API.Models.ProjectSummaryDoc;
using QABBB.API.Models.ProjectPlatform;

namespace QABBB.API.Models.Project
{
    public class ProjectDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; } = null!;
        public DateTime? StartDateTime { get; set; } = null!;
        public decimal? Duration { get; set; }
        public List<CompanyDTO> Developers { get; set; } = new List<CompanyDTO>()!;
        public List<CompanyDTO> Publishers { get; set; } = new List<CompanyDTO>()!;
        public List<ProjectPlatformDTO> ProjectPlatforms {get; set; } = new List<ProjectPlatformDTO>()!;

        
    }

}
