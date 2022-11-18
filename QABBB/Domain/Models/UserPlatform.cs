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
        public DateTime? RemovedAt { get; set; }

        public virtual Platform IdPlatformNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
