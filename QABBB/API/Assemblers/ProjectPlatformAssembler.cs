using QABBB.API.Models.Company;
using QABBB.API.Models.Platform;
using QABBB.API.Models.Project;
using QABBB.API.Models.ProjectPlatform;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectPlatformAssembler
    {
        public ProjectPlatformDTO toProjectPlatformDTO(ProjectPlatform projectPlatform) {

            ProjectPlatformDTO projectPlatformDTO = new ProjectPlatformDTO();
            projectPlatformDTO.IdProjectPlatform = projectPlatform.IdProjectPlatform;
            projectPlatformDTO.IdPlatform = projectPlatform.IdPlatform;
            projectPlatformDTO.CohortSize = projectPlatform.CohortSize;
            
            return projectPlatformDTO;
        }

        public ProjectPlatform toProject(ProjectPlatform projectPlatform, ProjectPlatformEditDTO projectPlatformEditDTO){
            projectPlatform.IdProjectPlatform = projectPlatformEditDTO.IdProjectPlatform;
            projectPlatform.IdPlatform = projectPlatformEditDTO.IdPlatform;
            projectPlatform.CohortSize = projectPlatformEditDTO.CohortSize;

            return projectPlatform;
        }

        public List<ProjectPlatformDTO> toProjectPlatformDTO(IEnumerable<ProjectPlatform> projectPlatforms) {

            List<ProjectPlatformDTO> projectPlatformDTO = new List<ProjectPlatformDTO>();

            foreach (ProjectPlatform projectPlatform in projectPlatforms) {
                projectPlatformDTO.Add(toProjectPlatformDTO(projectPlatform));
            }

            return projectPlatformDTO;
        }

        public ProjectPlatform toProjectPlatform(ProjectPlatformInputDTO projectPlatformInputDTO) {

            ProjectPlatform projectPlatform = new ProjectPlatform();
            projectPlatform.IdProject = projectPlatformInputDTO.IdProject;
            projectPlatform.IdPlatform = projectPlatformInputDTO.IdPlatform;
            projectPlatform.CohortSize = projectPlatformInputDTO.CohortSize;
            
            return projectPlatform;
        }
    }
}

