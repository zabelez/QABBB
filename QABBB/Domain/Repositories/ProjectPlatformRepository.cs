using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectPlatformRepository
    {
        private readonly QABBBContext _context;

        public ProjectPlatformRepository(QABBBContext context) {
            _context = context;
        }

        public List<ProjectPlatform> list(){
            return _context.ProjectPlatforms
                .Include(platform => platform.IdPlatformNavigation)
                .Include(projeto => projeto.IdProjectNavigation)
                .ToList();
        }

        public bool add(ProjectPlatform projectPlatform) {
            _context.ProjectPlatforms.Add(projectPlatform);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectPlatform projectPlatform){
            _context.Entry(projectPlatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectPlatform? findById(int id) {
            return _context.ProjectPlatforms
                .Include(platform => platform.IdPlatformNavigation)
                .Include(projeto => projeto.IdProjectNavigation)
                .Where(u => u.IdProjectPlatform == id)
                .FirstOrDefault();
        }

        public bool edit(ProjectPlatform projectPlatform){
            _context.Entry(projectPlatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(ProjectPlatform projectPlatform){
            _context.ProjectPlatforms.Remove(projectPlatform);
            _context.SaveChanges();
            return true;
        }
    }
}

