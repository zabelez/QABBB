using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class PublishEmloyeePosition
    {
        public PublishEmloyeePosition()
        {
            PublisherEmployees = new HashSet<PublisherEmployee>();
        }

        public int IdPublishEmloyeePosition { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PublisherEmployee> PublisherEmployees { get; set; }
    }
}
