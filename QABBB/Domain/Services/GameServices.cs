using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class GameServices
    {
        private readonly QABBBContext _context;
        private readonly GameRepository _gameRepository;

        public GameServices(QABBBContext context)
        {
            _context = context;
            _gameRepository = new GameRepository(_context);
        }

        public List<Game> list() {
            return _gameRepository.list();
        }

        public Game? findById(int id) {
            return _gameRepository.findById(id);
        }

        public bool add(Game game) {
            return _gameRepository.add(game) ? true : false;
        }

        public bool edit(Game game){
            return _gameRepository.edit(game);
        }
    }
}

