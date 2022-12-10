using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class GamePlatformServices
    {
        private readonly QABBBContext _context;
        private readonly GamePlatformRepository _gameRepository;

        public GamePlatformServices(QABBBContext context)
        {
            _context = context;
            _gameRepository = new GamePlatformRepository(_context);
        }

        public List<GamePlatform> list() {
            return _gameRepository.list();
        }

        public GamePlatform? findById(int id) {
            return _gameRepository.findById(id);
        }

        public List<GamePlatform>? findByIdGame(int idGame) {
            return _gameRepository.findByIdGame(idGame);
        }

        public bool add(GamePlatform gamePlatform, int idGame) {
            return _gameRepository.add(gamePlatform) ? true : false;
        }

        public bool edit(GamePlatform gamePlatform){
            return _gameRepository.edit(gamePlatform);
        }

        public bool delete(GamePlatform gamePlatform){
            return _gameRepository.delete(gamePlatform);
        }
    }
}

