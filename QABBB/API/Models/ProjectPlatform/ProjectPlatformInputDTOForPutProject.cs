using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectPlatform
{
    public class ProjectPlatformInputDTOForPutProject
    {
        public int IdProjectPlatform { get; set; }
        public int IdPlatform { get; set; }
        public int CohortSize { get; set; } = 0!;
    }
}