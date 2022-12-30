using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectDeveloper
{
    public class ProjectDeveloperInputDTO
    {
        [Required]
        public int IdProject { get; set; }
        [Required]
        public int IdCompany { get; set; }
    }
}