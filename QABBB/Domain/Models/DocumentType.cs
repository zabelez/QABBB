using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public int IdDocumentType { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; }
    }
}
