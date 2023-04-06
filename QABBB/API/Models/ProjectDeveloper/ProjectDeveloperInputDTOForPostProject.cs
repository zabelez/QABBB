using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectDeveloper
{
    public class ProjectDeveloperInputDTOForPostProject
    {
        [Required]
        [Range(1, int.MaxValue) ]
        public int IdCompany { get; set; }
    }
}