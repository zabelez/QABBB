using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Link
{
    public class LinkDTO
    {
        public int IdLink { get; set; }
        public string Type { get; set; } = null!;
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
