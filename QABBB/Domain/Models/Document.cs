using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class Document
    {
        public int IdDocument { get; set; }
        public string Uuid { get; set; } = null!;
        public int IdProject { get; set; }
        public int IdDocumentType { get; set; }
        public int IdDocumentStorage { get; set; }
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual DocumentStorage IdDocumentStorageNavigation { get; set; } = null!;
        public virtual DocumentType IdDocumentTypeNavigation { get; set; } = null!;
        public virtual Project IdProjectNavigation { get; set; } = null!;
    }
}
