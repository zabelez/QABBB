using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Company
    {
        public Company()
        {
            Developers = new HashSet<Developer>();
            Publishers = new HashSet<Publisher>();
        }

        public int IdCompany { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }

        public virtual ICollection<Developer> Developers { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
