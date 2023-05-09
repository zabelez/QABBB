using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.Document;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.API.Models.Link;
using QABBB.API.Models.ProjectPlatform;
using QABBB.API.Models.ProjectPublisher;

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
        public List<LinkInputDTOForPostProject>? Links { get; set; } = new List<LinkInputDTOForPostProject>()!;
        public List<DocumentInputDTOForPostProject>? Documents { get; set; } = new List<DocumentInputDTOForPostProject>()!;
        
    }
}
