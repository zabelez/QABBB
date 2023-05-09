using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Document
{
    public class DocumentEditDTO
    {
        public int IdDocument { get; set; }
        public int IdProject { get; set; }
        public string Label { get; set; } = null!;
        public string Uuid { get; set; } = null!;
        
    }
}
