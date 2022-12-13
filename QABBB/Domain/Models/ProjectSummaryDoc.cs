using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class ProjectSummaryDoc
    {
        public int IdProjectSummaryDoc { get; set; }
        public int IdProject { get; set; }
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual Project IdProjectNavigation { get; set; } = null!;
    }
}
