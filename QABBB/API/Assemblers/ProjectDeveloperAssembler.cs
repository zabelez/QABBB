using QABBB.API.Models.ProjectDeveloper;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectDeveloperAssembler
    {

        public ProjectDeveloperDTO toProjectDeveloperDTO(ProjectDeveloper projectdeveloper) {

            ProjectDeveloperDTO projectdeveloperDTO = new ProjectDeveloperDTO();
            projectdeveloperDTO.IdProjectDeveloper = projectdeveloper.IdProjectDeveloper;
            projectdeveloperDTO.IdProject = projectdeveloper.IdProject;
            projectdeveloperDTO.Project = projectdeveloper.IdProjectNavigation.Name;
            projectdeveloperDTO.IdCompany = projectdeveloper.IdCompany;
            projectdeveloperDTO.Company = projectdeveloper.IdCompanyNavigation.Name;
            
            return projectdeveloperDTO;
        }
        public ProjectDeveloperDTOForProject toProjectDeveloperDTOForProject(ProjectDeveloper projectdeveloper) {

            CompanyAssembler cAssembler = new CompanyAssembler();

            ProjectDeveloperDTOForProject pdDTO = new ProjectDeveloperDTOForProject();
            pdDTO.IdProjectDeveloper = projectdeveloper.IdProjectDeveloper;
            pdDTO.IdCompany = projectdeveloper.IdCompany;
            pdDTO.Company = cAssembler.toCompanyDTO(projectdeveloper.IdCompanyNavigation);
            
            return pdDTO;
        }

        public List<ProjectDeveloperDTO> toProjectDeveloperDTO(IEnumerable<ProjectDeveloper> companies) {

            List<ProjectDeveloperDTO> projectdeveloperDTO = new List<ProjectDeveloperDTO>();

            foreach (ProjectDeveloper projectdeveloper in companies) {
                projectdeveloperDTO.Add(toProjectDeveloperDTO(projectdeveloper));
            }

            return projectdeveloperDTO;
        }

        public ProjectDeveloper toProjectDeveloper(ProjectDeveloperInputDTO projectdeveloperInputDTO) {

            ProjectDeveloper projectdeveloper = new ProjectDeveloper();
            projectdeveloper.IdProject = projectdeveloperInputDTO.IdProject;
            projectdeveloper.IdCompany = projectdeveloperInputDTO.IdCompany;
            
            return projectdeveloper;
        }
    }
}

