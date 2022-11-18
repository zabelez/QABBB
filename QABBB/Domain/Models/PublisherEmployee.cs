using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class PublisherEmployee
    {
        public int IdPublisherEmployee { get; set; }
        public int IdPublisher { get; set; }
        public int IdUser { get; set; }
        public int IdPosition { get; set; }
        public string Status { get; set; } = null!;

        public virtual PublishEmloyeePosition IdPositionNavigation { get; set; } = null!;
        public virtual Publisher IdPublisherNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
