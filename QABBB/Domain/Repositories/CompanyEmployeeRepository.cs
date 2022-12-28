using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class CompanyEmployeeRepository
    {
        private readonly QABBBContext _context;

        public CompanyEmployeeRepository(QABBBContext context) {
            _context = context;
        }

        public List<CompanyEmployee> list(){
            return _context.CompanyEmployees
                .Include(u => u.IdCompanyNavigation)
                .Include(u => u.IdPersonNavigation.IdPersonNavigation)
                .Include(u => u.IdPositionNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Include(u => u.RemovedByNavigation!.IdPersonNavigation)
                .Where(u => u.RemovedAt == null)
                .ToList();
        }

        public bool add(CompanyEmployee companyEmployee) {
            _context.CompanyEmployees.Add(companyEmployee);
            _context.SaveChanges();
            return true;
        }

        public bool save(CompanyEmployee companyEmployee){
            _context.Entry(companyEmployee).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public CompanyEmployee? findById(int id) {
            return _context.CompanyEmployees
                .Include(u => u.IdCompanyNavigation)
                .Include(u => u.IdPersonNavigation.IdPersonNavigation)
                .Include(u => u.IdPositionNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Include(u => u.RemovedByNavigation!.IdPersonNavigation)
                .Where(u => u.IdCompanyEmployee == id && u.RemovedAt == null)
                .FirstOrDefault();
        }

        public bool edit(CompanyEmployee companyEmployee){
            _context.Entry(companyEmployee).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        internal List<CompanyEmployee>? findByIdCompany(int idCompany)
        {
            return _context.CompanyEmployees
                .Include(u => u.IdCompanyNavigation)
                .Include(u => u.IdPersonNavigation.IdPersonNavigation)
                .Include(u => u.IdPositionNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Include(u => u.RemovedByNavigation!.IdPersonNavigation)
                .Where(u => u.IdCompany == idCompany && u.RemovedAt == null)
                .ToList();
        }
    }
}

