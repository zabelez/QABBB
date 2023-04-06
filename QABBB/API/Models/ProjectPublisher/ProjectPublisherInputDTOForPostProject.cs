using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectPublisher {
    public class ProjectPublisherInputDTOForPostProject
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int IdCompany { get; set; }
    }
}