using QABBB.API.Models.Project.ProjectSummary;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectSummaryAssembler
    {

        public ProjectSummaryDTO toProjectSummaryDTO(ProjectSummaryDoc projectsummary) {

            ProjectSummaryDTO projectsummaryDTO = new ProjectSummaryDTO();
            projectsummaryDTO.IdProjectSummaryDoc = projectsummary.IdProjectSummaryDoc;
            projectsummaryDTO.IdProject = projectsummary.IdProject;
            projectsummaryDTO.Label = projectsummary.Label;
            projectsummaryDTO.Url = projectsummary.Url;
            
            return projectsummaryDTO;
        }

        public ProjectSummaryDoc toProjectSummary(ProjectSummaryDoc projectsummary, ProjectSummaryEditDTO projectsummaryEditInputDTO){
            projectsummary.IdProjectSummaryDoc = projectsummaryEditInputDTO.IdProjectSummaryDoc;
            projectsummary.IdProject = projectsummaryEditInputDTO.IdProject;
            projectsummary.Label = projectsummaryEditInputDTO.Label;
            projectsummary.Url = projectsummaryEditInputDTO.Url;

            return projectsummary;
        }

        public List<ProjectSummaryDTO> toProjectSummaryDTO(IEnumerable<ProjectSummaryDoc> companies) {

            List<ProjectSummaryDTO> projectsummaryDTO = new List<ProjectSummaryDTO>();

            foreach (ProjectSummaryDoc projectsummary in companies) {
                projectsummaryDTO.Add(toProjectSummaryDTO(projectsummary));
            }

            return projectsummaryDTO;
        }

        public ProjectSummaryDoc toProjectSummary(ProjectSummaryInputDTO projectsummaryInputDTO) {

            ProjectSummaryDoc projectsummary = new ProjectSummaryDoc();
            projectsummaryInputDTO.IdProject = projectsummary.IdProject;
            projectsummaryInputDTO.Label = projectsummary.Label;
            projectsummaryInputDTO.Url = projectsummary.Url;

            return projectsummary;
        }
    }
}

