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

        public bool add(ProjectFile projectfile) {
            return _projectFileRepository.add(projectfile);
        }

        public bool edit(ProjectFile projectfile){
            return _projectFileRepository.edit(projectfile);
        }

        public bool delete(ProjectFile projectfile){
            return _projectFileRepository.delete(projectfile);
        }
    }
}

