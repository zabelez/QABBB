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
    public class ProjectEditDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public DateTime StartDateTime { get; set; }
        public int? Duration { get; set; }
        public string? PowerBiUrl { get; set; }
        public string? SpreadsheetUrl { get; set; }
        public List<ProjectDeveloperInputDTOForPutProject> Developers { get; set; } = new List<ProjectDeveloperInputDTOForPutProject>()!;
        public List<ProjectPublisherInputDTOForPutProject> Publishers { get; set; } = new List<ProjectPublisherInputDTOForPutProject>()!;
        public List<ProjectFileInputDTOForPutProject>? ProjectFiles { get; set; } = new List<ProjectFileInputDTOForPutProject>()!;
        public List<ProjectFormInputDTOForPutProject>? ProjectForms { get; set; } = new List<ProjectFormInputDTOForPutProject>()!;
        public List<ProjectPlatformInputDTOForPutProject>? ProjectPlatforms { get; set; } = new List<ProjectPlatformInputDTOForPutProject>()!;
        public List<ProjectSummaryDocInputDTOForPutProject>? ProjectSummaryDocs { get; set; } = new List<ProjectSummaryDocInputDTOForPutProject>()!;
        public List<ProjectInterviewInputDTOForPutProject>? ProjectInterviews { get; set; } = new List<ProjectInterviewInputDTOForPutProject>()!;
        
    }
}
