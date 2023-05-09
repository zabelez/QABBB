using QABBB.API.Models.Link;
using QABBB.API.Models.ProjectPlatform;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.API.Models.ProjectPublisher;
using QABBB.API.Models.Document;

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
        public List<LinkDTO> Links {get; set; } = new List<LinkDTO>()!;
        public List<DocumentDTO> Documents {get; set; } = new List<DocumentDTO>()!;
        
    }

}
