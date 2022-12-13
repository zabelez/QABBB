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
            return _context.ProjectPlatforms.ToList();
        }

        public bool add(ProjectPlatform projectplatform) {
            _context.ProjectPlatforms.Add(projectplatform);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectPlatform projectplatform){
            _context.Entry(projectplatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectPlatform? findById(int id) {
            return _context.ProjectPlatforms.FirstOrDefault();
        }

        public bool edit(ProjectPlatform projectplatform){
            _context.Entry(projectplatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public bool delete(ProjectPlatform projectplatform){
            _context.ProjectPlatforms.Remove(projectplatform);
            _context.SaveChanges();
            return true;
        }
    }
}

