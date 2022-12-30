namespace QABBB.API.Models.ProjectDeveloper
{
    public class ProjectDeveloperDTO
    {
        public int IdProjectDeveloper { get; set; }
        public int IdProject { get; set; }
        public string? Project {get; set; }
        public int IdCompany { get; set; }
        public string? Company {get; set; }
    }
}