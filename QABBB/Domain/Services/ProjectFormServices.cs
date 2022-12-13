using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

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
    }
}

