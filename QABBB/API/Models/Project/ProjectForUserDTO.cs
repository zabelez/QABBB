namespace QABBB.API.Models.Project
{
    public class ProjectForUserDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; } = null!;
        public DateTime? StartDateTime { get; set; }
        public decimal? Duration { get; set; }
        
    }

}
