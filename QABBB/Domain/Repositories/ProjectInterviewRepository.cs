using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class ProjectInterviewRepository
    {
        private readonly QABBBContext _context;

        public ProjectInterviewRepository(QABBBContext context) {
            _context = context;
        }

        public List<ProjectInterview> list(){
            return _context.ProjectInterviews.ToList();
        }

        public bool add(ProjectInterview projectInterview) {
            _context.ProjectInterviews.Add(projectInterview);
            _context.SaveChanges();
            return true;
        }

        public bool save(ProjectInterview projectInterview){
            _context.Entry(projectInterview).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public ProjectInterview? findById(int id) {
            return _context.ProjectInterviews.FirstOrDefault();
        }

        public bool edit(ProjectInterview projectInterview){
            _context.Entry(projectInterview).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public bool delete(ProjectInterview projectInterview){
            _context.ProjectInterviews.Remove(projectInterview);
            _context.SaveChanges();
            return true;
        }
    }
}

