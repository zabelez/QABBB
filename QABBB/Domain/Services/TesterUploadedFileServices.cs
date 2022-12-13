using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;

namespace QABBB.Domain.Services
{
    public class TesterUploadedFileServices
    {
        private readonly QABBBContext _context;
        private readonly TesterUploadedFileRepository _testerUploadedFileRepository;

        public TesterUploadedFileServices(QABBBContext context) {
            _context = context;
            _testerUploadedFileRepository = new TesterUploadedFileRepository(_context);
        }

        public List<TesterUploadedFile> list() {
            return _testerUploadedFileRepository.list();
        }

        public TesterUploadedFile? findById(int id) {
            return _testerUploadedFileRepository.findById(id);
        }

        public bool add(TesterUploadedFile projectform) {
            return _testerUploadedFileRepository.add(projectform) ? true : false;
        }

        public bool edit(TesterUploadedFile projectform){
            return _testerUploadedFileRepository.edit(projectform);
        }

        public bool delete(TesterUploadedFile projectform){
            return _testerUploadedFileRepository.delete(projectform);
        }
    }
}

