using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectDeveloper
{
    public class ProjectDeveloperInputDTOForPutProject
    {
        [Required]
        public int IdCompany { get; set; }
    }
}