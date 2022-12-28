using QABBB.Data;
using QABBB.Domain.Repositories;
using QABBB.Models;

namespace QABBB.Domain.Services
{
    public class CompanyEmployeeServices
    {
        private readonly QABBBContext _context;
        private readonly CompanyEmployeeRepository _ceRepository;

        public CompanyEmployeeServices(QABBBContext context) {
            _context = context;
            _ceRepository = new CompanyEmployeeRepository(_context);
        }

        public List<CompanyEmployee> list() {
            return _ceRepository.list();
        }

        public CompanyEmployee? findById(int id) {
            return _ceRepository.findById(id);
        }

        public bool add(CompanyEmployee companyEmployee, int idPerson) {
            companyEmployee.CreatedBy = idPerson;
            companyEmployee.CreatedAt = DateTime.Now;

            return _ceRepository.add(companyEmployee) ? true : false;
        }

        public bool inactivate(CompanyEmployee companyEmployee, int idPerson){
            companyEmployee.RemovedBy = idPerson;
            companyEmployee.RemovedAt = DateTime.Now;

            return _ceRepository.edit(companyEmployee);
        }

        internal List<CompanyEmployee>? findByIdCompany(int idCompany)
        {
            return _ceRepository.findByIdCompany(idCompany);
        }
    }
}

