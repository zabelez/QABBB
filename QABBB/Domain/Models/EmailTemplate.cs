using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class EmailTemplate
    {
        public int IdEmailTemplate { get; set; }
        public string Html { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string Subject { get; set; } = null!;
    }
}
