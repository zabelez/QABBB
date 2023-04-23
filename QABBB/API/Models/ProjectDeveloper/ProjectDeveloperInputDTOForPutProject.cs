using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectDeveloper
{
    public class ProjectDeveloperInputDTOForPutProject
    {
        public int IdProjectDeveloper { get; set; }
        [Required]
        public int IdCompany { get; set; }
    }
}