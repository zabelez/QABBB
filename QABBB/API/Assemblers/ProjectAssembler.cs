using QABBB.API.Models.Company;
using QABBB.API.Models.Platform;
using QABBB.API.Models.Project;
using QABBB.API.Models.ProjectPlatform;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectAssembler
    {
        CompanyAssembler companyAssembler = new CompanyAssembler();

        public ProjectDTO toProjectDTO(Project project) {

            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.IdProject = project.IdProject;
            projectDTO.Name = project.Name;
            projectDTO.StartDateTime = project.StartDateTime;
            projectDTO.Duration = project.Duration;
            projectDTO.PowerBiUrl = project.PowerBiUrl;
            projectDTO.SpreadsheetUrl = project.SpreadsheetUrl;

            foreach (ProjectDeveloper projectDeveloper in project.ProjectDevelopers)
            {
                projectDTO.Developers.Add(companyAssembler.toCompanyDTO(projectDeveloper.IdCompanyNavigation));
            }

            foreach (ProjectPublisher projectPublisher in project.ProjectPublishers)
            {
                projectDTO.Publishers.Add(companyAssembler.toCompanyDTO(projectPublisher.IdCompanyNavigation));
            }

            foreach (ProjectPlatform projectPlatform in project.ProjectPlatforms)
            {
                ProjectPlatformDTO projectPlatformDTO = new ProjectPlatformDTO();
                projectPlatformDTO.IdProjectPlatform = projectPlatform.IdProjectPlatform;
                projectPlatformDTO.IdPlatform = projectPlatform.IdPlatform;
                projectPlatformDTO.Name = projectPlatform.IdPlatformNavigation.Name;
                projectPlatformDTO.Cohortsize = projectPlatform.CohortSize;
                projectDTO.Platforms.Add(projectPlatformDTO);
            }
            
            return projectDTO;
        }

        public Project toProject(Project project, ProjectEditDTO projectEditInputDTO){
            project.IdProject = projectEditInputDTO.IdProject;
            project.StartDateTime = projectEditInputDTO.StartDateTime;
            project.Name = projectEditInputDTO.Name;
            project.PowerBiUrl = projectEditInputDTO.PowerBiUrl;
            project.Duration = projectEditInputDTO.Duration;
            project.SpreadsheetUrl = projectEditInputDTO.SpreadsheetUrl;

            return project;
        }

        public List<ProjectDTO> toProjectDTO(IEnumerable<Project> companies) {

            List<ProjectDTO> projectDTO = new List<ProjectDTO>();

            foreach (Project project in companies) {
                projectDTO.Add(toProjectDTO(project));
            }

            return projectDTO;
        }

        public Project toProject(ProjectInputDTO projectInputDTO) {

            Project project = new Project();
            project.StartDateTime = projectInputDTO.StartDateTime;
            project.Name = projectInputDTO.Name;
            project.PowerBiUrl = projectInputDTO.PowerBiUrl;
            project.Duration = projectInputDTO.Duration;
            project.SpreadsheetUrl = projectInputDTO.SpreadsheetUrl;

            return project;
        }
    }
}

