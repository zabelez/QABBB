using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.ProjectForm;

namespace QABBB.Domain.Services
{
    public class ProjectFormServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectFormRepository _projectFormRepository;

        public ProjectFormServices(QABBBContext context) {
            _context = context;
            _projectFormRepository = new ProjectFormRepository(_context);
        }

        public List<ProjectForm> list() {
            return _projectFormRepository.list();
        }

        public ProjectForm? findById(int id) {
            return _projectFormRepository.findById(id);
        }

        public bool add(ProjectForm projectform) {
            return _projectFormRepository.add(projectform) ? true : false;
        }

        public bool edit(ProjectForm projectform){
            return _projectFormRepository.edit(projectform);
        }

        public bool delete(ProjectForm projectform){
            return _projectFormRepository.delete(projectform);
        }

        public ICollection<ProjectForm> editProject(ICollection<ProjectForm> projectForms, List<ProjectFormInputDTOForPutProject>? inputProjectForms)
        {
            foreach (var item in projectForms.Select((value, index) => new { value, index }))
            {
                if (!inputProjectForms.Exists(x => x.IdProjectForm == item.value.IdProjectForm))
                    projectForms.Remove(item.value);
            }

            foreach (ProjectFormInputDTOForPutProject item in inputProjectForms)
            {
                if (item.IdProjectForm == 0)
                {
                    ProjectForm? pd = this.findById(item.IdProjectForm);
                    if (pd != null)
                        projectForms.Add(pd);
                }
            }

            return projectForms;
        }
    }
}

