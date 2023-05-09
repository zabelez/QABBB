using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Link
{
    public class LinkInputDTO
    {
        public int IdProject { get; set; }
        public int IdLinkType { get; set; }
        public string Label { get; set; } = ""!;
        public string Url { get; set; } = ""!;
        
    }
}
