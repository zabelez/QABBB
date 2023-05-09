using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Document
{
    public class DocumentInputDTO
    {
        [Required]
        public int IdProject { get; set; }
        [Required]
        public int DocumentType { get; set; }
        [Required]
        public string Label { get; set; } = null!;
        [Required]
        public int DocumentStorage { get; set; }
        [Required]
        public string Url { get; set; } = null!;
        
    }
}
