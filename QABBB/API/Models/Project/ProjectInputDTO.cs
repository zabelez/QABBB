using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.API.Models.ProjectFile;
using QABBB.API.Models.ProjectForm;
using QABBB.API.Models.ProjectInterview;
using QABBB.API.Models.ProjectPlatform;
using QABBB.API.Models.ProjectPublisher;
using QABBB.API.Models.ProjectSummaryDoc;

namespace QABBB.API.Models.Project
{
    public class ProjectInputDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public DateTime StartDateTime { get; set; }
        public int? Duration { get; set; }
        public string? PowerBiUrl { get; set; }
        public string? SpreadsheetUrl { get; set; }
        public List<ProjectDeveloperInputDTOForPostProject>? Developers { get; set; } = new List<ProjectDeveloperInputDTOForPostProject>()!;
        public List<ProjectPublisherInputDTOForPostProject>? Publishers { get; set; } = new List<ProjectPublisherInputDTOForPostProject>()!;
        public List<ProjectPlatformInputDTOForPostProject>? ProjectPlatforms { get; set; } = new List<ProjectPlatformInputDTOForPostProject>()!;
        public List<ProjectFileInputDTOForPostProject>? ProjectFiles { get; set; } = new List<ProjectFileInputDTOForPostProject>()!;
        public List<ProjectFormInputDTOForPostProject>? ProjectForms { get; set; } = new List<ProjectFormInputDTOForPostProject>()!;
        public List<ProjectSummaryDocInputDTOForPostProject>? ProjectSummaryDocs { get; set; } = new List<ProjectSummaryDocInputDTOForPostProject>()!;
        public List<ProjectInterviewInputDTOForPostProject>? ProjectInterviews { get; set; } = new List<ProjectInterviewInputDTOForPostProject>()!;
        
    }
}
