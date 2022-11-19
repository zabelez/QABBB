using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class DeveloperEmployeePositionRepository
    {
        private readonly QABBBContext _context;

        public DeveloperEmployeePositionRepository(QABBBContext context) {
            _context = context;
        }

        public List<DeveloperEmployeePosition> list(){
            return _context.DeveloperEmployeePositions.ToList();
        }

        public bool add(DeveloperEmployeePosition developerEmployeePosition)
        {
            _context.DeveloperEmployeePositions.Add(developerEmployeePosition);
            _context.SaveChanges();
            return true;
        }

        public bool save(DeveloperEmployeePosition developerEmployeePosition){
            _context.Entry(developerEmployeePosition).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public DeveloperEmployeePosition? findById(int id) {
            return _context.DeveloperEmployeePositions
                .Where(u => u.IdDeveloperEmployeePosition == id)
                .FirstOrDefault();
        }

        public bool edit(DeveloperEmployeePosition developerEmployeePosition){
            _context.Entry(developerEmployeePosition).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

