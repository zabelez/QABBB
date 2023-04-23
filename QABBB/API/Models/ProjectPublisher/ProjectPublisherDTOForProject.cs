using QABBB.API.Models.Company;

namespace QABBB.API.Models.ProjectPublisher
{
    public class ProjectPublisherDTOForProject
    {
        public int IdProjectPublisher { get; set; }
        public int IdCompany { get; set; }
        public CompanyDTO Company {get; set; }
    }
}