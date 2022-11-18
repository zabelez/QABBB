using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Developer
    {
        public Developer()
        {
            DeveloperEmployees = new HashSet<DeveloperEmployee>();
            Games = new HashSet<Game>();
        }

        public int IdDeveloper { get; set; }
        public int IdCompany { get; set; }

        public virtual Company IdCompanyNavigation { get; set; } = null!;
        public virtual ICollection<DeveloperEmployee> DeveloperEmployees { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
