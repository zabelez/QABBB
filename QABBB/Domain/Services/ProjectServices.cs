using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.Project;
using QABBB.API.Models.ProjectDeveloper;

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

        public bool add(Project link) {
            return _projectRepository.add(link) ? true : false;
        }

        public bool edit(Project project, ProjectEditDTO projectEditDTO){

            ProjectDeveloperServices projectDeveloperServices = new ProjectDeveloperServices(_context);
            ProjectPublisherServices projectPublisherServices = new ProjectPublisherServices(_context);
            LinkServices linkServices = new LinkServices(_context);
            ProjectPlatformServices projectPlatformServices = new ProjectPlatformServices(_context);
            DocumentServices documentServices = new DocumentServices(_context);
            
            projectDeveloperServices.editProject(project.ProjectDevelopers, projectEditDTO.Developers);
            projectPublisherServices.editProject(project.ProjectPublishers, projectEditDTO.Publishers);
            projectPlatformServices.editProject(project.ProjectPlatforms, projectEditDTO.ProjectPlatforms);
            documentServices.editProject(project.Documents, projectEditDTO.Documents);
            linkServices.editProject(project.Links, projectEditDTO.Links);

            return _projectRepository.edit(project);
        }

        public bool delete(Project link){
            return _projectRepository.delete(link);
        }

        public List<Project> listByUser(int id) {
            return _projectRepository.listByUser(id);
        }

        public List<Project> listByCompany(int id) {
            return _projectRepository.listByCompany(id);
        }
    }
}

