using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class PlatformRepository
    {
        private readonly QABBBContext _context;

        public PlatformRepository(QABBBContext context) {
            _context = context;
        }

        public List<Platform> list(){
            return _context.Platforms
                    .OrderBy(u => u.Name)
                    .ToList();
        }

        public bool add(Platform platform)
        {
            _context.Platforms.Add(platform);
            _context.SaveChanges();
            return true;
        }

        public bool save(Platform platform){
            _context.Entry(platform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public Platform? findById(int id) {
            return _context.Platforms
                .Where(u => u.IdPlatform == id)
                .FirstOrDefault();
        }

        public bool edit(Platform platform){
            _context.Entry(platform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

