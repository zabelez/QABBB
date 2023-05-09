using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Link
{
    public class LinkInputDTOForPostProject
    {
        [Required]
        public int IdLinkType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        
    }
}
