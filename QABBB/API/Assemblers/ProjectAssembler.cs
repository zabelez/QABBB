using QABBB.API.Models.Project;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectAssembler
    {

        public ProjectDTO toProjectDTO(Project project) {

            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.IdProject = project.IdProject;
            projectDTO.StartDateTime = project.StartDateTime;
            projectDTO.PowerBiUrl = project.PowerBiUrl;
            projectDTO.Duration = project.Duration;
            projectDTO.CohortSize = project.CohortSize;
            projectDTO.SpreadsheetUrl = project.SpreadsheetUrl;
            
            return projectDTO;
        }

        public Project toProject(Project project, ProjectEditDTO projectEditInputDTO){
            project.IdProject = projectEditInputDTO.IdProject;
            project.StartDateTime = projectEditInputDTO.StartDateTime;
            project.PowerBiUrl = projectEditInputDTO.PowerBiUrl;
            project.Duration = projectEditInputDTO.Duration;
            project.CohortSize = projectEditInputDTO.CohortSize;
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
            project.PowerBiUrl = projectInputDTO.PowerBiUrl;
            project.Duration = projectInputDTO.Duration;
            project.CohortSize = projectInputDTO.CohortSize;
            project.SpreadsheetUrl = projectInputDTO.SpreadsheetUrl;

            return project;
        }
    }
}

