using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.ProjectPlatform;

namespace QABBB.Domain.Services
{
    public class ProjectPlatformServices
    {
        private readonly QABBBContext _context;
        private readonly ProjectPlatformRepository _projectplatformRepository;

        public ProjectPlatformServices(QABBBContext context) {
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
        public ICollection<ProjectPlatform> editProject(ICollection<ProjectPlatform> projectPlatforms, List<ProjectPlatformInputDTOForPutProject>? inputProjectPlatforms)
        {
            foreach (var item in projectPlatforms.Select((value, index) => new { value, index }))
            {
                if (!inputProjectPlatforms.Exists(x => x.IdProjectPlatform == item.value.IdProjectPlatform))
                    projectPlatforms.Remove(item.value);
            }

            foreach (ProjectPlatformInputDTOForPutProject item in inputProjectPlatforms)
            {
                if (item.IdProjectPlatform == 0)
                {
                    ProjectPlatform? pd = this.findById(item.IdPlatform);
                    if (pd != null)
                        projectPlatforms.Add(pd);
                }
            }

            return projectPlatforms;
        }
    }
}

