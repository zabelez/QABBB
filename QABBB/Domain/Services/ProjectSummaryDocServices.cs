using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

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
    }
}

