using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class ProjectPublisher
    {
        public int IdProjectPublisher { get; set; }
        public int IdProject { get; set; }
        public int IdCompany { get; set; }

        public virtual Company IdCompanyNavigation { get; set; } = null!;
        public virtual Project IdProjectNavigation { get; set; } = null!;
    }
}
