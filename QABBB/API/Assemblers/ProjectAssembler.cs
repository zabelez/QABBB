using QABBB.API.Models.Company;
using QABBB.API.Models.Platform;
using QABBB.API.Models.Project;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.API.Models.Link;
using QABBB.API.Models.ProjectPlatform;
using QABBB.API.Models.ProjectPublisher;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectAssembler
    {
        
        LinkAssembler LinkAssembler = new LinkAssembler();
        ProjectPlatformAssembler projectPlatformAssembler = new ProjectPlatformAssembler();
        
        public ProjectForUserDTO toProjectForUserDTO(Project project) {

            CompanyAssembler companyAssembler = new CompanyAssembler();

            ProjectForUserDTO projectDTO = new ProjectForUserDTO();
            projectDTO.IdProject = project.IdProject;
            projectDTO.Name = project.Name;
            projectDTO.Logo = project.Logo;
            projectDTO.StartDateTime = project.StartDateTime;
            projectDTO.Duration = project.Duration;
            
            
            return projectDTO;
        }

        public ProjectDTO toProjectDTO(Project project)
        {

            CompanyAssembler companyAssembler = new CompanyAssembler();

            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.IdProject = project.IdProject;
            projectDTO.Name = project.Name;
            projectDTO.Logo = project.Logo;
            projectDTO.StartDateTime = project.StartDateTime;
            projectDTO.Duration = project.Duration;

            foreach (ProjectDeveloper projectDeveloper in project.ProjectDevelopers)
            {
                projectDTO.Developers.Add(companyAssembler.toCompanyDTO(projectDeveloper.IdCompanyNavigation));
            }

            foreach (ProjectPublisher projectPublisher in project.ProjectPublishers)
            {
                projectDTO.Publishers.Add(companyAssembler.toCompanyDTO(projectPublisher.IdCompanyNavigation));
            }

            projectDTO.ProjectPlatforms = projectPlatformAssembler.toProjectPlatformDTO(project.ProjectPlatforms);

            return projectDTO;
        }
        public ProjectForDashboardScreenDTO toProjectForDashboardScreenDTO(Project project)
        {

            CompanyAssembler companyAssembler = new CompanyAssembler();

            ProjectForDashboardScreenDTO projectForDashboardScreenDTO = new ProjectForDashboardScreenDTO();
            projectForDashboardScreenDTO.IdProject = project.IdProject;
            projectForDashboardScreenDTO.Name = project.Name;
            projectForDashboardScreenDTO.Logo = project.Logo;
            projectForDashboardScreenDTO.StartDateTime = project.StartDateTime;
            projectForDashboardScreenDTO.Duration = project.Duration;

            foreach (ProjectDeveloper projectDeveloper in project.ProjectDevelopers)
            {
                projectForDashboardScreenDTO.Developers.Add(companyAssembler.toCompanyForDashboardScreenDTO(projectDeveloper.IdCompanyNavigation));
            }

            foreach (ProjectPublisher projectPublisher in project.ProjectPublishers)
            {
                projectForDashboardScreenDTO.Publishers.Add(companyAssembler.toCompanyForDashboardScreenDTO(projectPublisher.IdCompanyNavigation));
            }

            projectForDashboardScreenDTO.ProjectPlatforms = projectPlatformAssembler.toProjectPlatformForDashboardScreen(project.ProjectPlatforms);

            foreach (ProjectPlatform projectPlatform in project.ProjectPlatforms)
            {
                projectForDashboardScreenDTO.cohortSizeTotal += projectPlatform.CohortSize;
            }

            return projectForDashboardScreenDTO;
        }

        public ProjectFullDTO toProjectFullDTO(Project project)
        {
            ProjectDeveloperAssembler pdAssembler = new ProjectDeveloperAssembler();
            ProjectPublisherAssembler ppAssembler = new ProjectPublisherAssembler();
            DocumentAssembler docAssembler = new DocumentAssembler();
            CompanyAssembler companyAssembler = new CompanyAssembler();

            ProjectFullDTO projectFullDTO = new ProjectFullDTO();
            projectFullDTO.IdProject = project.IdProject;
            projectFullDTO.Name = project.Name;
            projectFullDTO.Logo = project.Logo;
            projectFullDTO.StartDateTime = project.StartDateTime;
            projectFullDTO.Duration = project.Duration;
            projectFullDTO.PowerBiUrl = project.PowerBiUrl;
            
            projectFullDTO.ProjectPlatforms = projectPlatformAssembler.toProjectPlatformDTO(project.ProjectPlatforms);

            foreach (ProjectDeveloper projectDeveloper in project.ProjectDevelopers)
            {
                projectFullDTO.Developers.Add(pdAssembler.toProjectDeveloperDTOForProject(projectDeveloper));
            }

            foreach (ProjectPublisher projectPublisher in project.ProjectPublishers)
            {
                projectFullDTO.Publishers.Add(ppAssembler.toProjectPublisherDTOForProject(projectPublisher));
            }

            foreach (Link item in project.Links)
            {
                projectFullDTO.Links.Add(LinkAssembler.toLinkDTO(item));
            }
            
            foreach (Document item in project.Documents)
            {
                projectFullDTO.Documents.Add(docAssembler.toDocumentDTO(item));
            }
            
            return projectFullDTO;
        }

        public Project toProject(Project project, ProjectEditDTO projectEditInputDTO){
            project.IdProject = projectEditInputDTO.IdProject;
            project.Name = projectEditInputDTO.Name;
            project.Logo = projectEditInputDTO.Logo;
            project.StartDateTime = projectEditInputDTO.StartDateTime;
            project.Duration = projectEditInputDTO.Duration;
            project.PowerBiUrl = projectEditInputDTO.PowerBiUrl;
            project.SpreadsheetUrl = projectEditInputDTO.SpreadsheetUrl;

            return project;
        }

        public List<ProjectDTO> toProjectDTO(IEnumerable<Project> projects) {

            List<ProjectDTO> projectDTO = new List<ProjectDTO>();

            foreach (Project project in projects) {
                projectDTO.Add(toProjectDTO(project));
            }

            return projectDTO;
        }

        public List<ProjectForDashboardScreenDTO> toProjectForDashboardScreenDTO(IEnumerable<Project> projects) {

            List<ProjectForDashboardScreenDTO> projectForDashboardScreenDTO = new List<ProjectForDashboardScreenDTO>();

            foreach (Project project in projects) {
                projectForDashboardScreenDTO.Add(toProjectForDashboardScreenDTO(project));
            }

            return projectForDashboardScreenDTO;
        }

        public Project toProject(ProjectInputDTO projectInputDTO) {

            Project project = new Project();
            project.StartDateTime = projectInputDTO.StartDateTime;
            project.Name = projectInputDTO.Name;
            project.Logo = projectInputDTO.Logo;
            project.Duration = projectInputDTO.Duration;
            project.PowerBiUrl = projectInputDTO.PowerBiUrl;
            project.SpreadsheetUrl = projectInputDTO.SpreadsheetUrl;

            return project;
        }
    }
}

