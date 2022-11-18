using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class DeveloperEmployee
    {
        public int IdDeveloperEmployee { get; set; }
        public int IdDeveloper { get; set; }
        public int IdUser { get; set; }
        public int IdPosition { get; set; }
        public string Status { get; set; } = null!;

        public virtual Developer IdDeveloperNavigation { get; set; } = null!;
        public virtual DeveloperEmployeePosition IdPositionNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
