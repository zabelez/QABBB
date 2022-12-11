using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class LogServices
    {
        private readonly QABBBContext _context;
        private readonly LogRepository _logRepository;

        public LogServices(QABBBContext context)
        {
            _context = context;
            _logRepository = new LogRepository(_context);
        }

        public List<Log>? findByIdUser(int idUser) {
            return _logRepository.findByIdUser(idUser);
        }

        public void add(string? ipAddress, int idUser) {
            if(ipAddress == null)
                return;
                
            Log log = new Log();
            log.IdUser = idUser;
            log.Ip = ipAddress;
            log.Date = DateTime.Now;

            _logRepository.add(log);
        }
    }
}

