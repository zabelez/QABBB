using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class UserPlatformServices
    {
        private readonly QABBBContext _context;
        private readonly UserPlatformRepository _upRepository;

        public UserPlatformServices(QABBBContext context)
        {
            _context = context;
            _upRepository = new UserPlatformRepository(_context);
        }

        public List<UserPlatform> list() {
            return _upRepository.list();
        }

        public UserPlatform? findById(int id) {
            return _upRepository.findById(id);
        }

        public List<UserPlatform>? findByIdUser(int idUser) {
            return _upRepository.findByIdUser(idUser);
        }

        public bool add(UserPlatform userPlatform, int idUser) {
            userPlatform.CreatedAt = DateTime.Now;
            userPlatform.CreatedBy = idUser;
            return _upRepository.add(userPlatform) ? true : false;
        }

        public bool edit(UserPlatform userPlatform){
            return _upRepository.edit(userPlatform);
        }

        public bool inactivate(UserPlatform userPlatform, int idPerson){
            userPlatform.RemovedBy = idPerson;
            userPlatform.RemovedAt = DateTime.Now;

            return _upRepository.edit(userPlatform);
        }
    }
}

