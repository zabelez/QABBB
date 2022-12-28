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
        public DateTime? StartDateTime { get; set; } = null!;
        public int? Duration { get; set; }
        public string? PowerBiUrl { get; set; }
        public string? SpreadsheetUrl { get; set; }
        public List<CompanyDTO> Developers { get; set; } = new List<CompanyDTO>()!;
        public List<CompanyDTO> Publishers { get; set; } = new List<CompanyDTO>()!;
        public List<ProjectPlatformDTO> Platforms {get; set; } = new List<ProjectPlatformDTO>()!;
        public List<ProjectFormDTO> ProjectForms {get; set; } = new List<ProjectFormDTO>()!;
        public List<ProjectFileDTO> ProjectFiles {get; set; } = new List<ProjectFileDTO>()!;
        public List<ProjectSummaryDocDTO> ProjectSummaryDocs {get; set; } = new List<ProjectSummaryDocDTO>()!;

        
    }

}
