using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Project
    {
        public Project()
        {
            Heatmaps = new HashSet<Heatmap>();
            ProjectFiles = new HashSet<ProjectFile>();
            ProjectForms = new HashSet<ProjectForm>();
            ProjectPlatforms = new HashSet<ProjectPlatform>();
            ProjectSummaryDocs = new HashSet<ProjectSummaryDoc>();
            TesterUploadedFiles = new HashSet<TesterUploadedFile>();
        }

        public int IdProject { get; set; }
        public DateTime StartDateTime { get; set; }
        public string? PowerBiUrl { get; set; }
        public int? Duration { get; set; }
        public string Name { get; set; } = null!;
        public int? CohortSize { get; set; }
        public string? SpreadsheetUrl { get; set; }

        public virtual ICollection<Heatmap> Heatmaps { get; set; }
        public virtual ICollection<ProjectFile> ProjectFiles { get; set; }
        public virtual ICollection<ProjectForm> ProjectForms { get; set; }
        public virtual ICollection<ProjectPlatform> ProjectPlatforms { get; set; }
        public virtual ICollection<ProjectSummaryDoc> ProjectSummaryDocs { get; set; }
        public virtual ICollection<TesterUploadedFile> TesterUploadedFiles { get; set; }
    }
}
