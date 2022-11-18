using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class DeveloperRepository
    {
        private readonly QABBBContext _context;

        public DeveloperRepository(QABBBContext context) {
            _context = context;
        }

        public List<Developer> list(){
            return _context.Developers
            .Include(u => u.IdCompanyNavigation)
            .OrderBy(u => u.IdCompanyNavigation.Name)
            .ToList();
        }

        public bool add(Developer company)
        {
            _context.Developers.Add(company);
            _context.SaveChanges();
            return true;
        }

        public bool save(Developer company){
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public Developer? findById(int id) {
            return _context.Developers
                .Where(u => u.IdDeveloper == id)
                .FirstOrDefault();
        }
    }
}

