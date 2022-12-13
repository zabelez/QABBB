using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectFileRepository
    {
        private readonly QABBBContext _context;

        public ProjectFileRepository(QABBBContext context) {
            _context = context;
        }

        public List<ProjectFile> list(){
            return _context.ProjectFiles.ToList();
        }

        public bool add(ProjectFile projectFile) {
            _context.ProjectFiles.Add(projectFile);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectFile projectFile){
            _context.Entry(projectFile).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectFile? findById(int id) {
            return _context.ProjectFiles.FirstOrDefault();
        }

        public bool edit(ProjectFile projectFile){
            _context.Entry(projectFile).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public bool delete(ProjectFile projectFile){
            _context.ProjectFiles.Remove(projectFile);
            _context.SaveChanges();
            return true;
        }
    }
}

