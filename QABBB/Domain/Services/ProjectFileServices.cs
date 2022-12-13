using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class ProjectFileServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectFileRepository _projectFileRepository;

        public ProjectFileServices(QABBBContext context) {
            _context = context;
            _projectFileRepository = new ProjectFileRepository(_context);
        }

        public List<ProjectFile> list() {
            return _projectFileRepository.list();
        }

        public ProjectFile? findById(int id) {
            return _projectFileRepository.findById(id);
        }

        public bool add(ProjectFile projectform) {
            return _projectFileRepository.add(projectform) ? true : false;
        }

        public bool edit(ProjectFile projectform){
            return _projectFileRepository.edit(projectform);
        }

        public bool delete(ProjectFile projectform){
            return _projectFileRepository.delete(projectform);
        }
    }
}

