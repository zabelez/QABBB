using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class PlatformServices
    {
        private readonly QABBBContext _context;
        private readonly PlatformRepository _ceRepository;

        public PlatformServices(QABBBContext context)
        {
            _context = context;
            _ceRepository = new PlatformRepository(_context);
        }

        public List<Platform> list() {
            return _ceRepository.list();
        }

        public Platform? findById(int id) {
            return _ceRepository.findById(id);
        }

        public bool add(Platform platform) {
            return _ceRepository.add(platform) ? true : false;
        }

        public bool edit(Platform platform){
            return _ceRepository.edit(platform);
        }
    }
}

