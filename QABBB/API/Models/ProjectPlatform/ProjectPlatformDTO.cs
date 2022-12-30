namespace QABBB.API.Models.ProjectPlatform {
    public class ProjectPlatformDTO
    {
        public int IdProjectPlatform { get; set; }
        public int IdPlatform { get; set; }
        public string Name {get; set; } = ""!;
        public int? CohortSize { get; set; }
    }
}