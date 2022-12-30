using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class ProjectPublisherServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectPublisherRepository _projectpublisherRepository;

        public ProjectPublisherServices(QABBBContext context) {
            _context = context;
            _projectpublisherRepository = new ProjectPublisherRepository(_context);
        }

        public List<ProjectPublisher> list() {
            return _projectpublisherRepository.list();
        }

        public ProjectPublisher? findById(int id) {
            return _projectpublisherRepository.findById(id);
        }

        public bool add(ProjectPublisher projectpublisherform) {
            return _projectpublisherRepository.add(projectpublisherform) ? true : false;
        }

        public bool delete(ProjectPublisher projectpublisherform){
            return _projectpublisherRepository.delete(projectpublisherform);
        }
    }
}

