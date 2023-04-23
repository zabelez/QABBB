using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class ProjectInterview
    {
        public int IdProjectInterview { get; set; }
        public int? IdProject { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        public virtual Project? IdProjectNavigation { get; set; }
    }
}
