using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectRepository
    {
        private readonly QABBBContext _context;

        public ProjectRepository(QABBBContext context) {
            _context = context;
        }

        public List<Project> list(){
            return _context.Projects
            .Include(pp => pp.ProjectPlatforms)
                .ThenInclude(p => p.IdPlatformNavigation)
            .Include(pg => pg.ProjectDevelopers)
                .ThenInclude(dev => dev.IdCompanyNavigation)
            .Include(pg => pg.ProjectPublishers)
                .ThenInclude(pub => pub.IdCompanyNavigation)
            .OrderByDescending(x => x.StartDateTime)
            .ToList();
        }

        public bool add(Project project) {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return true;
        }

        public bool save(Project project){
            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public Project? findById(int id) {
            return _context.Projects
                .Include(pfiles => pfiles.ProjectFiles)
                .Include(pforms => pforms.ProjectForms)
                .Include(psummary => psummary.ProjectSummaryDocs)
                .Include(pp => pp.ProjectPlatforms)
                    .ThenInclude(p => p.IdPlatformNavigation)
                .Include(pg => pg.ProjectDevelopers)
                    .ThenInclude(dev => dev.IdCompanyNavigation)
                .Include(pg => pg.ProjectPublishers)
                    .ThenInclude(pub => pub.IdCompanyNavigation)
                .Where(w => w.IdProject == id)
                .FirstOrDefault();
        }

        public bool edit(Project project){
            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(Project project){
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return true;
        }
    }
}

