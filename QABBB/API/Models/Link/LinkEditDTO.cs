using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Link
{
    public class LinkEditDTO
    {
        public int IdLink { get; set; }
        public int IdProject { get; set; }
        public string Type { get; set; } = null!;
        public string Label { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
