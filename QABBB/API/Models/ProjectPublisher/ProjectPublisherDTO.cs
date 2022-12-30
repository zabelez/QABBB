namespace QABBB.API.Models.ProjectPublisher
{
    public class ProjectPublisherDTO
    {
        public int IdProjectPublisher { get; set; }
        public int IdProject { get; set; }
        public string? Project {get; set; }
        public int IdCompany { get; set; }
        public string? Company {get; set; }
    }
}