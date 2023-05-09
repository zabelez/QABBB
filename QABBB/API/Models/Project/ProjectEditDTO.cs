using QABBB.API.Models.Document;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.API.Models.Link;
using QABBB.API.Models.ProjectPlatform;
using QABBB.API.Models.ProjectPublisher;

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
        public List<LinkInputDTOForPutProject>? Links { get; set; } = new List<LinkInputDTOForPutProject>()!;
        public List<ProjectPlatformInputDTOForPutProject>? ProjectPlatforms { get; set; } = new List<ProjectPlatformInputDTOForPutProject>()!;
        public List<DocumentInputDTOForPutProject>? Documents { get; set; } = new List<DocumentInputDTOForPutProject>()!;
        
    }
}
