using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class DocumentRepository
    {
        private readonly QABBBContext _context;

        public DocumentRepository(QABBBContext context)
        {
            _context = context;
        }

        public Document? findById(int id)
        {
            return _context.Documents
                .Where(u => u.IdDocument == id)
                .FirstOrDefault();
        }

        public Document? findByUuid(string uuid)
        {
            return _context.Documents
                .Where(u => u.Uuid == uuid)
                .FirstOrDefault();
        }

    }
}

