using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class TesterUploadedFile
    {
        public int IdTesterUploadedFiles { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual Project IdProjectNavigation { get; set; } = null!;
    }
}
