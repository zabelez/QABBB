using QABBB.API.Models.Company;

namespace QABBB.API.Models.ProjectDeveloper
{
    public class ProjectDeveloperDTOForProject
    {
        public int IdProjectDeveloper { get; set; }
        public int IdCompany { get; set; }
        public CompanyDTO Company {get; set; }
    }
}