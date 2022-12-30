using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectPublisher {
    public class ProjectPublisherInputDTO
    {
        [Required]
        public int IdProject { get; set; }
        [Required]
        public int IdCompany { get; set; }
    }
}