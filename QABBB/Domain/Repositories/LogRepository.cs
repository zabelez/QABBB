using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class LogRepository
    {
        private readonly QABBBContext _context;

        public LogRepository(QABBBContext context) {
            _context = context;
        }

        public bool add(Log log) {
            _context.Logs.Add(log);
            _context.SaveChanges();
            return true;
        }

        public List<Log>? findByIdUser(int idUser) {
            return _context.Logs
                .Include(u => u.IdUserNavigation.IdPersonNavigation)
                .Where(u => u.IdUser == idUser)
                .ToList();
        }
    }
}

