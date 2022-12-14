using QABBB.API.Models.Project.ProjectPlatform;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectPlatformAssembler
    {

        public ProjectPlatformDTO toProjectPlatformDTO(ProjectPlatform projectplatform) {

            ProjectPlatformDTO projectplatformDTO = new ProjectPlatformDTO();
            projectplatformDTO.IdProjectPlatform = projectplatform.IdProjectPlatform;
            projectplatformDTO.IdProject = projectplatform.IdProject;
            projectplatformDTO.IdGamePlatform = projectplatform.IdGamePlatform;
            
            return projectplatformDTO;
        }

        public ProjectPlatform toProjectPlatform(ProjectPlatform projectplatform, ProjectPlatformEditDTO projectplatformEditInputDTO){
            projectplatform.IdProjectPlatform = projectplatformEditInputDTO.IdProjectPlatform;
            projectplatform.IdProject = projectplatformEditInputDTO.IdProject;
            projectplatform.IdGamePlatform = projectplatformEditInputDTO.IdGamePlatform;

            return projectplatform;
        }

        public List<ProjectPlatformDTO> toProjectPlatformDTO(IEnumerable<ProjectPlatform> companies) {

            List<ProjectPlatformDTO> projectplatformDTO = new List<ProjectPlatformDTO>();

            foreach (ProjectPlatform projectplatform in companies) {
                projectplatformDTO.Add(toProjectPlatformDTO(projectplatform));
            }

            return projectplatformDTO;
        }

        public ProjectPlatform toProjectPlatform(ProjectPlatformInputDTO projectplatformInputDTO) {

            ProjectPlatform projectplatform = new ProjectPlatform();
            projectplatform.IdProject = projectplatformInputDTO.IdProject;
            projectplatform.IdGamePlatform = projectplatformInputDTO.IdGamePlatform;

            return projectplatform;
        }
    }
}

