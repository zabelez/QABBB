using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectDeveloperRepository
    {
        private readonly QABBBContext _context;

        public ProjectDeveloperRepository(QABBBContext context) {
            _context = context;
        }

        public List<ProjectDeveloper> list(){
            return _context.ProjectDevelopers
                .Include(company => company.IdCompanyNavigation)
                .Include(projeto => projeto.IdProjectNavigation)
                .ToList();
        }

        public bool add(ProjectDeveloper projectDeveloper) {
            _context.ProjectDevelopers.Add(projectDeveloper);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectDeveloper projectDeveloper){
            _context.Entry(projectDeveloper).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectDeveloper? findById(int id) {
            return _context.ProjectDevelopers
                .Include(company => company.IdCompanyNavigation)
                .Include(projeto => projeto.IdProjectNavigation)
                .Where(u => u.IdProjectDeveloper == id)
                .FirstOrDefault();
        }

        public bool edit(ProjectDeveloper projectDeveloper){
            _context.Entry(projectDeveloper).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

