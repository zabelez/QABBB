using QABBB.API.Models.ProjectInterview;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class ProjectInterviewAssembler
    {

        public ProjectInterviewDTO toProjectInterviewDTO(ProjectInterview projectinterview) {

            ProjectInterviewDTO projectinterviewDTO = new ProjectInterviewDTO();
            projectinterviewDTO.IdProjectInterview = projectinterview.IdProjectInterview;
            projectinterviewDTO.Name = projectinterview.Name;
            projectinterviewDTO.Url = projectinterview.Url;
            
            return projectinterviewDTO;
        }

        public ProjectInterview toProjectInterview(ProjectInterview projectinterview, ProjectInterviewEditDTO projectinterviewEditInputDTO){
            projectinterview.IdProjectInterview = projectinterviewEditInputDTO.IdProjectInterview;
            projectinterview.IdProject = projectinterviewEditInputDTO.IdProject;
            projectinterview.Name = projectinterviewEditInputDTO.Name;
            projectinterview.Url = projectinterviewEditInputDTO.Url;

            return projectinterview;
        }

        public List<ProjectInterviewDTO> toProjectInterviewDTO(IEnumerable<ProjectInterview> companies) {

            List<ProjectInterviewDTO> projectinterviewDTO = new List<ProjectInterviewDTO>();

            foreach (ProjectInterview projectinterview in companies) {
                projectinterviewDTO.Add(toProjectInterviewDTO(projectinterview));
            }

            return projectinterviewDTO;
        }

        public ProjectInterview toProjectInterview(ProjectInterviewInputDTO projectinterviewInputDTO) {

            ProjectInterview projectinterview = new ProjectInterview();
            projectinterview.IdProject = projectinterviewInputDTO.IdProject;
            projectinterview.Name = projectinterviewInputDTO.Name;
            projectinterview.Url = projectinterviewInputDTO.Url;

            return projectinterview;
        }
    }
}

