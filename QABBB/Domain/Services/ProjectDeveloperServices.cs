using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.ProjectDeveloper;

namespace QABBB.Domain.Services
{
    public class ProjectDeveloperServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectDeveloperRepository _projectdeveloperRepository;

        public ProjectDeveloperServices(QABBBContext context) {
            _context = context;
            _projectdeveloperRepository = new ProjectDeveloperRepository(_context);
        }

        public List<ProjectDeveloper> list() {
            return _projectdeveloperRepository.list();
        }

        public ProjectDeveloper? findById(int id) {
            return _projectdeveloperRepository.findById(id);
        }

        public bool add(ProjectDeveloper projectdeveloperform) {
            return _projectdeveloperRepository.add(projectdeveloperform) ? true : false;
        }

        public bool delete(ProjectDeveloper projectdeveloperform){
            return _projectdeveloperRepository.delete(projectdeveloperform);
        }

        public ICollection<ProjectDeveloper> editProject(ICollection<ProjectDeveloper> projectDevelopers, List<ProjectDeveloperInputDTOForPutProject> inputProjectDevelopers){

            foreach (var item in projectDevelopers.Select((value, index) => new { value, index }))
            {
                if (!inputProjectDevelopers.Exists(x => x.IdCompany == item.value.IdCompany))
                    projectDevelopers.Remove(item.value);
            }

            foreach (ProjectDeveloperInputDTOForPutProject item in inputProjectDevelopers)
            {
                if (item.IdProjectDeveloper == 0)
                {
                    ProjectDeveloper? pd = this.findById(item.IdCompany);
                    if(pd != null)
                        projectDevelopers.Add(pd);
                }
            }
            
            return projectDevelopers;
        }
    }
}

