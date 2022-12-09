using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyEmployees = new HashSet<CompanyEmployee>();
            GameIdDeveloperNavigations = new HashSet<Game>();
            GameIdPublisherNavigations = new HashSet<Game>();
        }

        public int IdCompany { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }

        public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; }
        public virtual ICollection<Game> GameIdDeveloperNavigations { get; set; }
        public virtual ICollection<Game> GameIdPublisherNavigations { get; set; }
    }
}
