using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Document
{
    public class DocumentDTO
    {
        public int IdDocument { get; set; }
        public string Type { get; set; } = null!;
        public string Label { get; set; } = null!;
        public string Uuid { get; set; } = null!;
        
        
    }
}
