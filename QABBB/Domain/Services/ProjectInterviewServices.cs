using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.ProjectInterview;

namespace QABBB.Domain.Services
{
    public class ProjectInterviewServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectInterviewRepository _projectInterviewRepository;

        public ProjectInterviewServices(QABBBContext context) {
            _context = context;
            _projectInterviewRepository = new ProjectInterviewRepository(_context);
        }

        // public List<ProjectInterview> list() {
        //     return _projectInterviewRepository.list();
        // }

        public ProjectInterview? findById(int id) {
            return _projectInterviewRepository.findById(id);
        }

        // public bool add(ProjectInterview projectinterview) {
        //     return _projectInterviewRepository.add(projectinterview);
        // }

        // public bool edit(ProjectInterview projectinterview){
        //     return _projectInterviewRepository.edit(projectinterview);
        // }

        // public bool delete(ProjectInterview projectinterview){
        //     return _projectInterviewRepository.delete(projectinterview);
        // }

        public ICollection<ProjectInterview> editProject(ICollection<ProjectInterview> projectInterviews, List<ProjectInterviewInputDTOForPutProject>? inputProjectInterviews)
        {
            foreach (var item in projectInterviews.Select((value, index) => new { value, index }))
            {
                if (!inputProjectInterviews.Exists(x => x.IdProjectInterview == item.value.IdProjectInterview))
                    projectInterviews.Remove(item.value);
            }

            foreach (ProjectInterviewInputDTOForPutProject item in inputProjectInterviews)
            {
                if (item.IdProjectInterview == 0)
                {
                    ProjectInterview? pd = this.findById(item.IdProjectInterview);
                    if (pd != null)
                        projectInterviews.Add(pd);
                }
            }

            return projectInterviews;
        }
    }
}

