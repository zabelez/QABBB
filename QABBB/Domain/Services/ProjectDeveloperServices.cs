using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

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
    }
}

