using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.ProjectPublisher {
    public class ProjectPublisherInputDTOForPutProject
    {
        public int IdProjectPublisher { get; set; }
        [Required]
        public int IdCompany { get; set; }
    }
}