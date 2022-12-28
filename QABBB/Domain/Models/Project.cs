﻿using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectDevelopers = new HashSet<ProjectDeveloper>();
            ProjectFiles = new HashSet<ProjectFile>();
            ProjectForms = new HashSet<ProjectForm>();
            ProjectPlatforms = new HashSet<ProjectPlatform>();
            ProjectPublishers = new HashSet<ProjectPublisher>();
            ProjectSummaryDocs = new HashSet<ProjectSummaryDoc>();
        }

        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? StartDateTime { get; set; }
        public int? Duration { get; set; }
        public string? PowerBiUrl { get; set; }
        public string? SpreadsheetUrl { get; set; }

        public virtual ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
        public virtual ICollection<ProjectFile> ProjectFiles { get; set; }
        public virtual ICollection<ProjectForm> ProjectForms { get; set; }
        public virtual ICollection<ProjectPlatform> ProjectPlatforms { get; set; }
        public virtual ICollection<ProjectPublisher> ProjectPublishers { get; set; }
        public virtual ICollection<ProjectSummaryDoc> ProjectSummaryDocs { get; set; }
    }
}
