using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.API.Models.ProjectFile;

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

        public ICollection<ProjectFile> editProject(ICollection<ProjectFile> projectFiles, List<ProjectFileInputDTOForPutProject>? inputProjectFiles)
        {
            foreach (var item in projectFiles.Select((value, index) => new { value, index }))
            {
                if (!inputProjectFiles.Exists(x => x.IdProjectFile == item.value.IdProjectFile))
                    projectFiles.Remove(item.value);
            }

            foreach (ProjectFileInputDTOForPutProject item in inputProjectFiles)
            {
                if (item.IdProjectFile == 0)
                {
                    ProjectFile? pd = this.findById(item.IdProjectFile);
                    if (pd != null)
                        projectFiles.Add(pd);
                }
            }

            return projectFiles;
        }
    }
}

