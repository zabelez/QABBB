using QABBB.API.Models.Project.ProjectForm;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectFormAssembler
    {

        public ProjectFormDTO toProjectFormDTO(ProjectForm projectform) {

            ProjectFormDTO projectformDTO = new ProjectFormDTO();
            projectformDTO.IdProjectForm = projectform.IdProjectForm;
            projectformDTO.IdProject = projectform.IdProject;
            projectformDTO.Name = projectform.Name;
            projectformDTO.Url = projectform.Url;
            
            return projectformDTO;
        }

        public ProjectForm toProjectForm(ProjectForm projectform, ProjectFormEditDTO projectformEditInputDTO){
            projectform.IdProjectForm = projectformEditInputDTO.IdProjectForm;
            projectform.IdProject = projectformEditInputDTO.IdProject;
            projectform.Name = projectformEditInputDTO.Name;
            projectform.Url = projectformEditInputDTO.Url;

            return projectform;
        }

        public List<ProjectFormDTO> toProjectFormDTO(IEnumerable<ProjectForm> companies) {

            List<ProjectFormDTO> projectformDTO = new List<ProjectFormDTO>();

            foreach (ProjectForm projectform in companies) {
                projectformDTO.Add(toProjectFormDTO(projectform));
            }

            return projectformDTO;
        }

        public ProjectForm toProjectForm(ProjectFormInputDTO projectformInputDTO) {

            ProjectForm projectform = new ProjectForm();
            projectform.IdProject = projectformInputDTO.IdProject;
            projectform.Name = projectformInputDTO.Name;
            projectform.Url = projectformInputDTO.Url;

            return projectform;
        }
    }
}

