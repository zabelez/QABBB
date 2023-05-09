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
                .Include(pdocs => pdocs.Documents)
                    .ThenInclude(pdoc => pdoc.IdDocumentStorageNavigation)
                .Include(pdocs => pdocs.Documents)
                    .ThenInclude(pdoc => pdoc.IdDocumentTypeNavigation)
                .Include(pdocs => pdocs.Links)
                    .ThenInclude(pdoc => pdoc.IdLinkTypeNavigation)
                .Include(pp => pp.ProjectPlatforms)
                    .ThenInclude(p => p.IdPlatformNavigation)
                .Include(pg => pg.ProjectDevelopers)
                    .ThenInclude(dev => dev.IdCompanyNavigation)
                        .ThenInclude(com => com.CompanyEmployees)
                            .ThenInclude(per => per.IdPersonNavigation)
                                .ThenInclude(x => x.IdPersonNavigation)
                .Include(pg => pg.ProjectDevelopers)
                    .ThenInclude(dev => dev.IdCompanyNavigation)
                        .ThenInclude(com => com.CompanyEmployees)
                            .ThenInclude(pos => pos.IdPositionNavigation)

                .Include(pg => pg.ProjectPublishers)
                    .ThenInclude(dev => dev.IdCompanyNavigation)
                        .ThenInclude(com => com.CompanyEmployees)
                            .ThenInclude(per => per.IdPersonNavigation)
                                .ThenInclude(x => x.IdPersonNavigation)
                .Include(pg => pg.ProjectPublishers)
                    .ThenInclude(dev => dev.IdCompanyNavigation)
                        .ThenInclude(com => com.CompanyEmployees)
                            .ThenInclude(pos => pos.IdPositionNavigation)
                        
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

        internal List<Project> listByUser(int id)
        {
            return _context.Projects
            .Include(pp => pp.ProjectPlatforms)
                .ThenInclude(p => p.IdPlatformNavigation)
            .Include(pg => pg.ProjectDevelopers)
                .ThenInclude(dev => dev.IdCompanyNavigation)
            .Include(pg => pg.ProjectPublishers)
                .ThenInclude(pub => pub.IdCompanyNavigation)
            .Where(p => p.ProjectDevelopers
                            .Any(dev => dev.IdCompanyNavigation.CompanyEmployees
                                .Any(p => p.IdPerson == id)) 
                    || p.ProjectPublishers
                            .Any(pub => pub.IdCompanyNavigation.CompanyEmployees
                                .Any(p => p.IdPerson == id))
            )
            .OrderByDescending(x => x.StartDateTime)
            .ToList();
        }

        internal List<Project> listByCompany(int id)
        {
            return _context.Projects
            .Include(pp => pp.ProjectPlatforms)
                .ThenInclude(p => p.IdPlatformNavigation)
            .Include(pg => pg.ProjectDevelopers)
                .ThenInclude(dev => dev.IdCompanyNavigation)
            .Include(pg => pg.ProjectPublishers)
                .ThenInclude(pub => pub.IdCompanyNavigation)
            .Where(p => p.ProjectDevelopers
                            .Any(dev => dev.IdCompany == id) 
                    || p.ProjectPublishers
                            .Any(pub => pub.IdCompany == id)
            )
            .OrderByDescending(x => x.StartDateTime)
            .ToList();
        }
    }
}

