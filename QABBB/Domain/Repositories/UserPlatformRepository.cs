using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class UserPlatformRepository
    {
        private readonly QABBBContext _context;

        public UserPlatformRepository(QABBBContext context) {
            _context = context;
        }

        public List<UserPlatform> list(){
            return _context.UserPlatforms.ToList();
        }

        public bool add(UserPlatform userPlatform)
        {
            _context.UserPlatforms.Add(userPlatform);
            _context.SaveChanges();
            return true;
        }

        public bool save(UserPlatform userPlatform){
            _context.Entry(userPlatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public UserPlatform? findById(int id) {
            return _context.UserPlatforms
                .Where(u => u.IdUserPlatform == id && u.RemovedBy == null)
                .FirstOrDefault();
        }

        public List<UserPlatform>? findByIdUser(int idUser) {
            return _context.UserPlatforms
                .Include(u => u.IdUserNavigation.IdPersonNavigation)
                .Include(u => u.CreatedByNavigation.IdPersonNavigation)
                .Include(u => u.RemovedByNavigation!.IdPersonNavigation)
                .Include(u => u.IdPlatformNavigation)
                .Where(u => u.IdUser == idUser && u.RemovedBy == null)
                .ToList();
        }

        public bool edit(UserPlatform userPlatform){
            _context.Entry(userPlatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

