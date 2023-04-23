using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.ProjectSummaryDoc;

namespace QABBB.Domain.Services
{
    public class ProjectSummaryDocServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectSummaryDocRepository _projectSummaryDocRepository;

        public ProjectSummaryDocServices(QABBBContext context) {
            _context = context;
            _projectSummaryDocRepository = new ProjectSummaryDocRepository(_context);
        }

        public List<ProjectSummaryDoc> list() {
            return _projectSummaryDocRepository.list();
        }

        public ProjectSummaryDoc? findById(int id) {
            return _projectSummaryDocRepository.findById(id);
        }

        public bool add(ProjectSummaryDoc projectform) {
            return _projectSummaryDocRepository.add(projectform) ? true : false;
        }

        public bool edit(ProjectSummaryDoc projectform){
            return _projectSummaryDocRepository.edit(projectform);
        }

        public bool delete(ProjectSummaryDoc projectform){
            return _projectSummaryDocRepository.delete(projectform);
        }
        public ICollection<ProjectSummaryDoc> editProject(ICollection<ProjectSummaryDoc> projectSummaryDocs, List<ProjectSummaryDocInputDTOForPutProject>? inputProjectSummaryDocs)
        {
            foreach (var item in projectSummaryDocs.Select((value, index) => new { value, index }))
            {
                if (!inputProjectSummaryDocs.Exists(x => x.IdProjectSummaryDoc == item.value.IdProjectSummaryDoc))
                    projectSummaryDocs.Remove(item.value);
            }

            foreach (ProjectSummaryDocInputDTOForPutProject item in inputProjectSummaryDocs)
            {
                if (item.IdProjectSummaryDoc == 0)
                {
                    ProjectSummaryDoc? pd = this.findById(item.IdProjectSummaryDoc);
                    if (pd != null)
                        projectSummaryDocs.Add(pd);
                }
            }

            return projectSummaryDocs;
        }
    }
}

