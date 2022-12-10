using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class GameRepository
    {
        private readonly QABBBContext _context;

        public GameRepository(QABBBContext context) {
            _context = context;
        }

        public List<Game> list() {
            return _context.Games
                .Include(u => u.IdDeveloperNavigation)
                .Include(u => u.IdPublisherNavigation)
                .ToList();
        }

        public bool add(Game game) {
            _context.Games.Add(game);
            _context.SaveChanges();
            return true;
        }

        public bool save(Game game){
            _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public Game? findById(int id) {
            return _context.Games
                .Include(u => u.IdDeveloperNavigation)
                .Include(u => u.IdPublisherNavigation)
                .Include(u => u.GamePlatforms)
                    .ThenInclude(u => u.IdPlatformNavigation)
                .Where(u => u.IdGame == id)
                .FirstOrDefault();
        }

        public bool edit(Game game){
            _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}

