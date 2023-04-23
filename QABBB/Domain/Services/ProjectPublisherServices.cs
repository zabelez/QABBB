using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.ProjectPublisher;

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

        public ICollection<ProjectPublisher> editProject(ICollection<ProjectPublisher> projectPublishers, List<ProjectPublisherInputDTOForPutProject>? inputProjectPublishers)
        {
            foreach (var item in projectPublishers.Select((value, index) => new { value, index }))
            {
                if (!inputProjectPublishers.Exists(x => x.IdCompany == item.value.IdCompany))
                    projectPublishers.Remove(item.value);
            }

            foreach (ProjectPublisherInputDTOForPutProject item in inputProjectPublishers)
            {
                if (item.IdProjectPublisher == 0)
                {
                    ProjectPublisher? pd = this.findById(item.IdCompany);
                    if(pd != null)
                        projectPublishers.Add(pd);
                }
            }
            
            return projectPublishers;
        }
    }
}

