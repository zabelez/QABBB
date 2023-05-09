using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Link
    {
        public int IdLink { get; set; }
        public int IdProject { get; set; }
        public int IdLinkType { get; set; }
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual LinkType IdLinkTypeNavigation { get; set; } = null!;
        public virtual Project IdProjectNavigation { get; set; } = null!;
    }
}
