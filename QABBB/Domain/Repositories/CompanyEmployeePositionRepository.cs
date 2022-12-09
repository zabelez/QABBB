using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class CompanyEmployeePositionRepository
    {
        private readonly QABBBContext _context;

        public CompanyEmployeePositionRepository(QABBBContext context) {
            _context = context;
        }

        public List<CompanyEmployeePosition> list(){
            return _context.CompanyEmployeePositions.ToList();
        }

        public bool add(CompanyEmployeePosition companyEmployeePosition) {
            _context.CompanyEmployeePositions.Add(companyEmployeePosition);
            _context.SaveChanges();
            return true;
        }

        public bool save(CompanyEmployeePosition companyEmployeePosition){
            _context.Entry(companyEmployeePosition).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public CompanyEmployeePosition? findById(int id) {
            return _context.CompanyEmployeePositions.FirstOrDefault();
        }

        public bool edit(CompanyEmployeePosition companyEmployeePosition){
            _context.Entry(companyEmployeePosition).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

