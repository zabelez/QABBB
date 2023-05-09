using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Document
{
    public class DocumentInputDTOForPostProject
    {
        [Required]
        public int DocumentType { get; set; }
        [Required]
        public string Label { get; set; } = null!;
        [Required]
        public int DocumentStorage { get; set; }
        [Required]
        public string Link { get; set; } = null!;
        
    }
}
