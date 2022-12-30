using QABBB.API.Models.ProjectPublisher;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectPublisherAssembler
    {

        public ProjectPublisherDTO toProjectPublisherDTO(ProjectPublisher projectpublisher) {

            ProjectPublisherDTO projectpublisherDTO = new ProjectPublisherDTO();
            projectpublisherDTO.IdProjectPublisher = projectpublisher.IdProjectPublisher;
            projectpublisherDTO.IdProject = projectpublisher.IdProject;
            projectpublisherDTO.Project = projectpublisher.IdProjectNavigation.Name;
            projectpublisherDTO.IdCompany = projectpublisher.IdCompany;
            projectpublisherDTO.Company = projectpublisher.IdCompanyNavigation.Name;
            
            return projectpublisherDTO;
        }

        public List<ProjectPublisherDTO> toProjectPublisherDTO(IEnumerable<ProjectPublisher> companies) {

            List<ProjectPublisherDTO> projectpublisherDTO = new List<ProjectPublisherDTO>();

            foreach (ProjectPublisher projectpublisher in companies) {
                projectpublisherDTO.Add(toProjectPublisherDTO(projectpublisher));
            }

            return projectpublisherDTO;
        }

        public ProjectPublisher toProjectPublisher(ProjectPublisherInputDTO projectpublisherInputDTO) {

            ProjectPublisher projectpublisher = new ProjectPublisher();
            projectpublisher.IdProject = projectpublisherInputDTO.IdProject;
            projectpublisher.IdCompany = projectpublisherInputDTO.IdCompany;
            
            return projectpublisher;
        }
    }
}

