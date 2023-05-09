using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class LinkType
    {
        public LinkType()
        {
            Links = new HashSet<Link>();
        }

        public int IdLinkType { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Link> Links { get; set; }
    }
}
