using QABBB.API.Models.Project.ProjectFile;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectFileAssembler
    {

        public ProjectFileDTO toProjectFileDTO(ProjectFile projectfile) {

            ProjectFileDTO projectfileDTO = new ProjectFileDTO();
            projectfileDTO.IdProjectFile = projectfile.IdProjectFile;
            projectfileDTO.IdProject = projectfile.IdProject;
            projectfileDTO.Name = projectfile.Name;
            projectfileDTO.Url = projectfile.Url;
            
            return projectfileDTO;
        }

        public ProjectFile toProjectFile(ProjectFile projectfile, ProjectFileEditDTO projectfileEditInputDTO){
            projectfile.IdProjectFile = projectfileEditInputDTO.IdProjectFile;
            projectfile.IdProject = projectfileEditInputDTO.IdProject;
            projectfile.Name = projectfileEditInputDTO.Name;
            projectfile.Url = projectfileEditInputDTO.Url;

            return projectfile;
        }

        public List<ProjectFileDTO> toProjectFileDTO(IEnumerable<ProjectFile> companies) {

            List<ProjectFileDTO> projectfileDTO = new List<ProjectFileDTO>();

            foreach (ProjectFile projectfile in companies) {
                projectfileDTO.Add(toProjectFileDTO(projectfile));
            }

            return projectfileDTO;
        }

        public ProjectFile toProjectFile(ProjectFileInputDTO projectfileInputDTO) {

            ProjectFile projectfile = new ProjectFile();
            projectfileInputDTO.IdProject = projectfile.IdProject;
            projectfileInputDTO.Name = projectfile.Name;
            projectfileInputDTO.Url = projectfile.Url;

            return projectfile;
        }
    }
}

