using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.Company;
using QABBB.API.Models.Platform;
using QABBB.API.Models.ProjectFile;
using QABBB.API.Models.ProjectForm;
using QABBB.API.Models.Heatmap;
using QABBB.API.Models.ProjectSummaryDoc;
using QABBB.API.Models.ProjectPlatform;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.API.Models.ProjectInterview;
using QABBB.API.Models.ProjectPublisher;

namespace QABBB.API.Models.Project
{
    public class ProjectFullDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public DateTime? StartDateTime { get; set; }
        public decimal? Duration { get; set; }
        public string? PowerBiUrl { get; set; }
        public List<ProjectDeveloperDTOForProject> Developers { get; set; } = new List<ProjectDeveloperDTOForProject>()!;
        public List<ProjectPublisherDTOForProject> Publishers { get; set; } = new List<ProjectPublisherDTOForProject>()!;
        public List<ProjectPlatformDTO> ProjectPlatforms {get; set; } = new List<ProjectPlatformDTO>()!;
        public List<ProjectFileDTO> ProjectFiles {get; set; } = new List<ProjectFileDTO>()!;
        public List<ProjectFormDTO> ProjectForms {get; set; } = new List<ProjectFormDTO>()!;
        public List<ProjectSummaryDocDTO> ProjectSummaryDocs {get; set; } = new List<ProjectSummaryDocDTO>()!;
        public List<ProjectInterviewDTO> ProjectInterviews {get; set; } = new List<ProjectInterviewDTO>()!;

        
    }

}
