using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectSummaryDocRepository
    {
        private readonly QABBBContext _context;

        public ProjectSummaryDocRepository(QABBBContext context) {
            _context = context;
        }

        public List<ProjectSummaryDoc> list(){
            return _context.ProjectSummaryDocs.ToList();
        }

        public bool add(ProjectSummaryDoc projectSummaryDoc) {
            _context.ProjectSummaryDocs.Add(projectSummaryDoc);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectSummaryDoc projectSummaryDoc){
            _context.Entry(projectSummaryDoc).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectSummaryDoc? findById(int id) {
            return _context.ProjectSummaryDocs.FirstOrDefault();
        }

        public bool edit(ProjectSummaryDoc projectSummaryDoc){
            _context.Entry(projectSummaryDoc).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(ProjectSummaryDoc projectSummaryDoc){
            _context.ProjectSummaryDocs.Remove(projectSummaryDoc);
            _context.SaveChanges();
            return true;
        }
    }
}

