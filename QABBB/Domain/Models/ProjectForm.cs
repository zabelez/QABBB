using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class ProjectForm
    {
        public int IdProjectForm { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual Project IdProjectNavigation { get; set; } = null!;
    }
}
