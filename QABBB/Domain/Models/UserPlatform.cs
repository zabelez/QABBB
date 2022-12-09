using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class UserPlatform
    {
        public int IdUserPlatform { get; set; }
        public int IdUser { get; set; }
        public int IdPlatform { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? RemovedAt { get; set; }
        public int? RemovedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual Platform IdPlatformNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual User? RemovedByNavigation { get; set; }
    }
}
