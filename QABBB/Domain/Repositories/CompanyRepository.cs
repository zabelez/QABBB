using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class CompanyRepository
    {
        private readonly QABBBContext _context;

        public CompanyRepository(QABBBContext context) {
            _context = context;
        }

        public List<Company> list(){
            return _context.Companies
                .Include(ce => ce.CompanyEmployees)
                    .ThenInclude(u => u.IdPositionNavigation)
                .Include(ce => ce.CompanyEmployees)
                    .ThenInclude(pe => pe.IdPersonNavigation)
                        .ThenInclude(pe => pe.IdPersonNavigation)
                .OrderBy(n => n.Name)
                .ToList();
        }

        public bool add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return true;
        }

        public bool save(Company company){
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public Company? findById(int id) {
            return _context.Companies
                .Where(u => u.IdCompany == id)
                .FirstOrDefault();
        }

        public bool edit(Company company){
            _context.Entry(company).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

