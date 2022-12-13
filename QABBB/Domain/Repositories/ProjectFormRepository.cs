using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectFormRepository
    {
        private readonly QABBBContext _context;

        public ProjectFormRepository(QABBBContext context) {
            _context = context;
        }

        public List<ProjectForm> list(){
            return _context.ProjectForms.ToList();
        }

        public bool add(ProjectForm projectForm) {
            _context.ProjectForms.Add(projectForm);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectForm projectForm){
            _context.Entry(projectForm).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectForm? findById(int id) {
            return _context.ProjectForms.FirstOrDefault();
        }

        public bool edit(ProjectForm projectForm){
            _context.Entry(projectForm).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(ProjectForm projectForm){
            _context.ProjectForms.Remove(projectForm);
            _context.SaveChanges();
            return true;
        }
    }
}

