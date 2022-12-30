using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectPublisherRepository
    {
        private readonly QABBBContext _context;

        public ProjectPublisherRepository(QABBBContext context) {
            _context = context;
        }

        public List<ProjectPublisher> list(){
            return _context.ProjectPublishers
                .Include(company => company.IdCompanyNavigation)
                .Include(projeto => projeto.IdProjectNavigation)
                .ToList();
        }

        public bool add(ProjectPublisher projectPublisher) {
            _context.ProjectPublishers.Add(projectPublisher);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectPublisher projectPublisher){
            _context.Entry(projectPublisher).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectPublisher? findById(int id) {
            return _context.ProjectPublishers
                .Include(company => company.IdCompanyNavigation)
                .Include(projeto => projeto.IdProjectNavigation)
                .Where(u => u.IdProjectPublisher == id)
                .FirstOrDefault();
        }

        public bool edit(ProjectPublisher projectPublisher){
            _context.Entry(projectPublisher).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

