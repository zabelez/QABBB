using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.Models;

namespace QABBB.Domain.Services
{
    public class CompanyEmployeePositionServices
    {
        private readonly QABBBContext _context;
        private readonly CompanyEmployeePositionRepository _cepRepository;

        public CompanyEmployeePositionServices(QABBBContext context) {
            _context = context;
            _cepRepository = new CompanyEmployeePositionRepository(_context);
        }

        public List<CompanyEmployeePosition> list() {
            return _cepRepository.list();
        }

        public CompanyEmployeePosition? findById(int id) {
            return _cepRepository.findById(id);
        }

        public bool add(CompanyEmployeePosition companyEmployeePosition) {
            return _cepRepository.add(companyEmployeePosition);
        }
    }
}

