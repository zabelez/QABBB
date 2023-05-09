using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Project
    {
        public Project()
        {
            Documents = new HashSet<Document>();
            Links = new HashSet<Link>();
            ProjectDevelopers = new HashSet<ProjectDeveloper>();
            ProjectPlatforms = new HashSet<ProjectPlatform>();
            ProjectPublishers = new HashSet<ProjectPublisher>();
        }

        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public DateTime? StartDateTime { get; set; }
        public decimal? Duration { get; set; }
        public string? PowerBiUrl { get; set; }
        public string? SpreadsheetUrl { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
        public virtual ICollection<ProjectPlatform> ProjectPlatforms { get; set; }
        public virtual ICollection<ProjectPublisher> ProjectPublishers { get; set; }
    }
}
