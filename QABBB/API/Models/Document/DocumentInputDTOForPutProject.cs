using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Document
{
    public class DocumentInputDTOForPutProject
    {
        public int IdDocument { get; set; }
        public int IdProject { get; set; }
        public int DocumentType { get; set; }
        public string Label { get; set; } = null!;
        public int DocumentStorage { get; set; }
        public string Link { get; set; } = null!;
        
    }
}
