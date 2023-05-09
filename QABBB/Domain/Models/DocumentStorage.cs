using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class DocumentStorage
    {
        public DocumentStorage()
        {
            Documents = new HashSet<Document>();
        }

        public int IdDocumentStorage { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; }
    }
}
