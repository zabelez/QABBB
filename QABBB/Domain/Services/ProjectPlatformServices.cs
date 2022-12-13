using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class ProjectPlatformPlatformServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectPlatformRepository _projectplatformRepository;

        public ProjectPlatformPlatformServices(QABBBContext context) {
            _context = context;
            _projectplatformRepository = new ProjectPlatformRepository(_context);
        }

        public List<ProjectPlatform> list() {
            return _projectplatformRepository.list();
        }

        public ProjectPlatform? findById(int id) {
            return _projectplatformRepository.findById(id);
        }

        public bool add(ProjectPlatform projectplatformform) {
            return _projectplatformRepository.add(projectplatformform) ? true : false;
        }

        public bool edit(ProjectPlatform projectplatformform){
            return _projectplatformRepository.edit(projectplatformform);
        }

        public bool delete(ProjectPlatform projectplatformform){
            return _projectplatformRepository.delete(projectplatformform);
        }
    }
}

