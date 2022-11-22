using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class DeveloperEmployeeRepository
    {
        private readonly QABBBContext _context;

        public DeveloperEmployeeRepository(QABBBContext context) {
            _context = context;
        }

        public List<DeveloperEmployee> list(){
            return _context.DeveloperEmployees.ToList();
        }

        public bool add(DeveloperEmployee developerEmploy)
        {
            _context.DeveloperEmployees.Add(developerEmploy);
            _context.SaveChanges();
            return true;
        }

        public bool save(DeveloperEmployee developerEmploy){
            _context.Entry(developerEmploy).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public DeveloperEmployee? findById(int id) {
            return _context.DeveloperEmployees
                .Where(u => u.IdDeveloperEmployee == id)
                .FirstOrDefault();
        }

        public bool edit(DeveloperEmployee developerEmploy){
            _context.Entry(developerEmploy).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

