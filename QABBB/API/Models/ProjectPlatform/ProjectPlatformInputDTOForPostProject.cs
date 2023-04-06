using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectPlatform
{
    public class ProjectPlatformInputDTOForPostProject
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int IdPlatform { get; set; }
        public int CohortSize { get; set; } = 0!;
    }
}