using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.Project;

namespace QABBB.Domain.Services
{
    public class ProjectServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectRepository _projectRepository;

        public ProjectServices(QABBBContext context) {
            _context = context;
            _projectRepository = new ProjectRepository(_context);
        }

        public List<Project> list() {
            return _projectRepository.list();
        }

        public Project? findById(int id) {
            return _projectRepository.findById(id);
        }

        public bool add(Project projectform) {
            return _projectRepository.add(projectform) ? true : false;
        }

        public bool edit(Project projectform){
            return _projectRepository.edit(projectform);
        }

        public bool delete(Project projectform){
            return _projectRepository.delete(projectform);
        }

        public List<Project> listByUser(int id) {
            return _projectRepository.listByUser(id);
        }

        public List<Project> listByCompany(int id) {
            return _projectRepository.listByCompany(id);
        }
    }
}

