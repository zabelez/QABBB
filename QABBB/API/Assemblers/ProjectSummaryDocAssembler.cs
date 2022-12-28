using QABBB.API.Models.ProjectSummaryDoc;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectSummaryDocAssembler
    {

        public ProjectSummaryDocDTO toProjectSummaryDocDTO(ProjectSummaryDoc projectsummary) {

            ProjectSummaryDocDTO projectsummaryDTO = new ProjectSummaryDocDTO();
            projectsummaryDTO.IdProjectSummaryDoc = projectsummary.IdProjectSummaryDoc;
            projectsummaryDTO.IdProject = projectsummary.IdProject;
            projectsummaryDTO.Label = projectsummary.Label;
            projectsummaryDTO.Url = projectsummary.Url;
            
            return projectsummaryDTO;
        }

        public ProjectSummaryDoc toProjectSummaryDoc(ProjectSummaryDoc projectsummary, ProjectSummaryDocEditDTO projectsummaryEditInputDTO){
            projectsummary.IdProjectSummaryDoc = projectsummaryEditInputDTO.IdProjectSummaryDoc;
            projectsummary.IdProject = projectsummaryEditInputDTO.IdProject;
            projectsummary.Label = projectsummaryEditInputDTO.Label;
            projectsummary.Url = projectsummaryEditInputDTO.Url;

            return projectsummary;
        }

        public List<ProjectSummaryDocDTO> toProjectSummaryDocDTO(IEnumerable<ProjectSummaryDoc> companies) {

            List<ProjectSummaryDocDTO> projectsummaryDTO = new List<ProjectSummaryDocDTO>();

            foreach (ProjectSummaryDoc projectsummary in companies) {
                projectsummaryDTO.Add(toProjectSummaryDocDTO(projectsummary));
            }

            return projectsummaryDTO;
        }

        public ProjectSummaryDoc toProjectSummaryDoc(ProjectSummaryDocInputDTO projectsummaryInputDTO) {

            ProjectSummaryDoc projectsummary = new ProjectSummaryDoc();
            projectsummary.IdProject = projectsummaryInputDTO.IdProject;
            projectsummary.Label = projectsummaryInputDTO.Label;
            projectsummary.Url = projectsummaryInputDTO.Url;

            return projectsummary;
        }
    }
}

