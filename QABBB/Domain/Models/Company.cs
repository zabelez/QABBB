using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyEmployees = new HashSet<CompanyEmployee>();
            InverseCompanyParentNavigation = new HashSet<Company>();
            ProjectDevelopers = new HashSet<ProjectDeveloper>();
            ProjectPublishers = new HashSet<ProjectPublisher>();
        }

        public int IdCompany { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public int? CompanyParent { get; set; }

        public virtual Company? CompanyParentNavigation { get; set; }
        public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; }
        public virtual ICollection<Company> InverseCompanyParentNavigation { get; set; }
        public virtual ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
        public virtual ICollection<ProjectPublisher> ProjectPublishers { get; set; }
    }
}
