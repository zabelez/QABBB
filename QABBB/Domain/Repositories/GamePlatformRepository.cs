using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class GamePlatformRepository
    {
        private readonly QABBBContext _context;

        public GamePlatformRepository(QABBBContext context) {
            _context = context;
        }

        public List<GamePlatform> list(){
            return _context.GamePlatforms.ToList();
        }

        public bool add(GamePlatform gamePlatform)
        {
            _context.GamePlatforms.Add(gamePlatform);
            _context.SaveChanges();
            return true;
        }

        public bool save(GamePlatform gamePlatform){
            _context.Entry(gamePlatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public GamePlatform? findById(int id) {
            return _context.GamePlatforms
                .Where(u => u.IdGamePlatform == id)
                .FirstOrDefault();
        }

        public List<GamePlatform>? findByIdGame(int idGame) {
            return _context.GamePlatforms
                .Include(u => u.IdGameNavigation)
                .Include(u => u.IdPlatformNavigation)
                .Where(u => u.IdGame == idGame)
                .ToList();
        }

        public bool edit(GamePlatform gamePlatform){
            _context.Entry(gamePlatform).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(GamePlatform gamePlatform){
            _context.GamePlatforms.Remove(gamePlatform);
            _context.SaveChanges();
            return true;
        }
    }
}

