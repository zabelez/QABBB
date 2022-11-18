using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class AdminRepository
    {
        private readonly QABBBContext _context;

        public AdminRepository(QABBBContext context)
        {
            _context = context;
        }

        public bool add(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return true;
        }

        public bool save(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public List<Admin> findAll()
        {
            return _context.Admins
                .Include(u => u.IdUserNavigation.IdPersonNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Include(u => u.RemovedByNavigation.IdPersonNavigation)
                .Where(u => u.RemovedBy == null)
                .OrderBy(u => u.IdUserNavigation.IdPersonNavigation.PersonName)
                .ToList();
        }

        public Admin? findById(int id)
        {
            return _context.Admins
                .Include(u => u.IdUserNavigation.IdPersonNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Include(u => u.RemovedByNavigation.IdPersonNavigation)
                .Where(u => u.IdAdmin == id)
                .FirstOrDefault();
        }

        public Admin? findByIdActive(int id)
        {
            return _context.Admins
                .Include(u => u.IdUserNavigation.IdPersonNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Where(u => u.IdAdmin == id && u.RemovedBy == null)
                .FirstOrDefault();
        }

        public Admin? findByIdUser(int id)
        {
            return _context.Admins
                .Include(u => u.IdUserNavigation.IdPersonNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Include(u => u.RemovedByNavigation.IdPersonNavigation)
                .Where(u => u.IdUser == id && u.RemovedAt == null)
                .FirstOrDefault();
        }
    }
}

