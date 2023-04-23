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

        public bool add(Project projectform) {
            return _projectRepository.add(projectform) ? true : false;
        }

        public bool edit(Project project, ProjectEditDTO projectEditDTO){

            ProjectDeveloperServices projectDeveloperServices = new ProjectDeveloperServices(_context);
            ProjectPublisherServices projectPublisherServices = new ProjectPublisherServices(_context);
            ProjectFileServices projectFileServices = new ProjectFileServices(_context);
            ProjectFormServices projectFormServices = new ProjectFormServices(_context);
            ProjectPlatformServices projectPlatformServices = new ProjectPlatformServices(_context);
            ProjectSummaryDocServices projectSummaryDocServices = new ProjectSummaryDocServices(_context);
            ProjectInterviewServices projectInterviewServices = new ProjectInterviewServices(_context);
            
            projectDeveloperServices.editProject(project.ProjectDevelopers, projectEditDTO.Developers);
            projectPublisherServices.editProject(project.ProjectPublishers, projectEditDTO.Publishers);
            projectFileServices.editProject(project.ProjectFiles, projectEditDTO.ProjectFiles);
            projectFormServices.editProject(project.ProjectForms, projectEditDTO.ProjectForms);
            projectPlatformServices.editProject(project.ProjectPlatforms, projectEditDTO.ProjectPlatforms);
            projectSummaryDocServices.editProject(project.ProjectSummaryDocs, projectEditDTO.ProjectSummaryDocs);
            projectInterviewServices.editProject(project.ProjectInterviews, projectEditDTO.ProjectInterviews);

            return _projectRepository.edit(project);
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

