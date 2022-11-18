using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class DeveloperEmployeePosition
    {
        public DeveloperEmployeePosition()
        {
            DeveloperEmployees = new HashSet<DeveloperEmployee>();
        }

        public int IdDeveloperEmployeePosition { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DeveloperEmployee> DeveloperEmployees { get; set; }
    }
}
